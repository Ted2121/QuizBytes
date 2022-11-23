using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using SQLAccessImplementationLibrary;
using SQLAccessImplementationLibraryUnitTest;
using WebApiClient;
using WebApiClient.DTOs;

namespace WebclientWebserverIntegrationTesting;

[TestFixture]
public class ChallengeFacadeTests
{
    private IChallengeFacadeApiClient _challangeFacadeApiClient = new ChallengeFacadeApiClient(Configuration.WEB_API_URI);
    private IWebUserFacadeApiClient _webUserFacadeApiClient = new WebUserFacadeApiClient(Configuration.WEB_API_URI);

    private IWebUserDataAccess _webUserDataAccess = new WebUserDataAccess(Configuration.CONNECTION_STRING);
    private ICourseDataAccess _courseDataAccess = new CourseDataAccess(Configuration.CONNECTION_STRING);
    private IChapterDataAccess _chapterDataAccess = new ChapterDataAccess(Configuration.CONNECTION_STRING);
    private ISubjectDataAccess _subjectDataAccess = new SubjectDataAccess(Configuration.CONNECTION_STRING);
    private ICurrentChallengeParticipantDataAccess _currentChallengeParticipantDataAccess = new CurrentChallengeParticipantDataAccessMock();
    private IQuestionDataAccess _questionDataAccess = new QuestionDataAccess(Configuration.CONNECTION_STRING);
    private IAnswerDataAccess _answerDataAccess = new AnswerDataAccess(Configuration.CONNECTION_STRING);

    private WebUserDto _userDto;
    private WebUserDto _secondUserDto;
    private CourseDto _courseDto;
    private Course _courseToInsert;
    private Subject _subjectToInsert;
    private Chapter _chapterToInsert;

    private CurrentChallengeParticipantDto _currentChallengeParticipantDto;


    public WebUserDto WebUserDto { get; set; }

    private async Task<WebUserDto> CreateAndInsertNewWebUserAsync()
    {
        _userDto = new WebUserDto()
        {
            Username = "Bob",
            PasswordHash = "BobProtecc",
            Email = "bob@Bob.com",
            TotalPoints = 0,
            AvailablePoints = 0,
            NumberOfCorrectAnswers = 4
        };
        _userDto.Id = await _webUserDataAccess.InsertWebUserAsync(_userDto.FromDto());

        return _userDto;
    }

    private async Task<CourseDto> CreateAndInsertNewCourseAsync()
    {
        _courseDto = new CourseDto()
        {
            Name = "sys dev",
            Description = "this is a description",

        };
        _courseDto.Id = await _courseDataAccess.InsertCourseAsync(_courseDto.FromDto());

        return _courseDto;
    }

    private async Task<CurrentChallengeParticipantDto> CreateNewCurrentChallengeParticipantDtoAsync()
    {
        var user = await CreateAndInsertNewWebUserAsync();
        var course = await CreateAndInsertNewCourseAsync();

        _currentChallengeParticipantDto = new CurrentChallengeParticipantDto()
        {
            WebUser = user,
            Course = course
        };

        return _currentChallengeParticipantDto;
    }




    [SetUp]
    public async Task SetUpAsync() => await CreateNewCurrentChallengeParticipantDtoAsync();


    [TearDown]
    public async Task CleanUpAsync()
    {
        await _courseDataAccess.DeleteCourseAsync(_courseDto.Id);
        await _webUserDataAccess.DeleteWebUserAsync(_userDto.Id);

    }

    [Test]
    public async Task TestingRegisterParticipantExpectingPositiveResult()
    {
        try
        {
            // Arrange
            var numberOfParticipantsBeforeRegistration = await _challangeFacadeApiClient.GetNumberOfParticipantsAsync();

            // Act
            await _challangeFacadeApiClient.RegisterParticipantAsync(_userDto, _courseDto);
            var numberOfParticipantsAfterRegistration = await _challangeFacadeApiClient.GetNumberOfParticipantsAsync();

            // Assert
            Assert.That(numberOfParticipantsAfterRegistration, Is.EqualTo(numberOfParticipantsBeforeRegistration + 1));
        }
        finally
        {
            await _currentChallengeParticipantDataAccess.DeleteWebUserFromChallengeAsync(_userDto.Id);
        }

    }

    [Test]
    public async Task CheckingNumberOfParticipantsExpectingOneMoreAfterInsertion()
    {
        try
        {
            // Arrange
            var numberOfParticipantsBeforeRegistration = await _challangeFacadeApiClient.GetNumberOfParticipantsAsync();
            await _challangeFacadeApiClient.RegisterParticipantAsync(_userDto, _courseDto);

            // Act
            var numberOfParticipantsAfterRegistration = await _challangeFacadeApiClient.GetNumberOfParticipantsAsync();

            // Assert
            Assert.That(numberOfParticipantsAfterRegistration, Is.EqualTo(numberOfParticipantsBeforeRegistration + 1));

        }
        finally
        {
            await _challangeFacadeApiClient.DeregisterParticipantAsync(_userDto.Id);
        }
    }

    [Test]
    public async Task TestingDeregisteringParticipantReturnsTrue()
    {

        // Arrange
        await _challangeFacadeApiClient.RegisterParticipantAsync(_userDto, _courseDto);


        // Act
        var result = await _challangeFacadeApiClient.DeregisterParticipantAsync(_userDto.Id);

        // Assert
        Assert.That(result, Is.True);

    }

    [Test]
    public async Task CheckingIfUserIsInChallengeReturnsTrue()
    {
        try
        {
            // Arrange

            await _challangeFacadeApiClient.RegisterParticipantAsync(_userDto, _courseDto);


            // Act
            var result = await _challangeFacadeApiClient.CheckIfUserIsInChallengeAsync(_userDto.Id);

            // Assert
            Assert.That(result, Is.True);

        }
        finally
        {
            await _currentChallengeParticipantDataAccess.DeleteWebUserFromChallengeAsync(_userDto.Id);
        }

    }


    [Test]
    public async Task CheckingIfUserIsInChallengeWithoutInsertionReturnsFalse()
    {

        // Arrange in SetUp

        // Act
        var result = await _challangeFacadeApiClient.CheckIfUserIsInChallengeAsync(_userDto.Id);

        // Assert
        Assert.That(result, Is.False);

    }

    [Test]
    public async Task TestingIfGettingAllParticipantsHasAnyParticipantExpectingTrue()
    {
        try
        {
            // Arrange
            await _challangeFacadeApiClient.RegisterParticipantAsync(_userDto, _courseDto);

            // Act
            var participants = await _challangeFacadeApiClient.GetAllParticipantsAsync();

            // Assert
            Assert.That(participants.Any(), Is.True);

        }
        finally
        {
            await _challangeFacadeApiClient.DeregisterParticipantAsync(_userDto.Id);
        }
    }

    [Test]
    public async Task TestingIfGettingAllParticipantsHasAnyParticipantExpectingFalse()
    {
        // Arrange
        await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
        // Act
        var participants = await _challangeFacadeApiClient.GetAllParticipantsAsync();

        // Assert
        Assert.That(participants.Any(), Is.False);
    }

    [Test]
    public async Task TestingRewardsDistributionExpectingAvailablePointsToBeAddedToUser()
    {

        try
        {
            // Arrange
            _secondUserDto = new WebUserDto()
            {
                Username = "Joe",
                PasswordHash = "JoeProtecc",
                Email = "joe@Bob.com",
                TotalPoints = 0,
                AvailablePoints = 0,
                NumberOfCorrectAnswers = 5
            };

            _secondUserDto.Id = await _webUserDataAccess.InsertWebUserAsync(_secondUserDto.FromDto());



            await _challangeFacadeApiClient.RegisterParticipantAsync(_secondUserDto, _courseDto);
            await _challangeFacadeApiClient.RegisterParticipantAsync(_userDto, _courseDto);

            List<WebUserDto> leaderboard = new List<WebUserDto>()
            {
                _userDto,
                _secondUserDto
            };
            LeaderboardDto leaderboardDto = new LeaderboardDto();
            leaderboardDto.Leaderboard = leaderboard;
            var availablePointsBeforeDistribution = _secondUserDto.AvailablePoints;

            var secondPlaceReward = 128;
            var pointsPerCorrectAnswer = 8;
            var pointsToBeAdded = (_secondUserDto.NumberOfCorrectAnswers * pointsPerCorrectAnswer) + secondPlaceReward;

            // Act

            await _challangeFacadeApiClient.DistributeRewardsAsync(leaderboardDto);
            var secondUser = await _webUserDataAccess.GetWebUserByIdAsync(_secondUserDto.Id);
            var availablePointsAfterDistribution = secondUser.AvailablePoints;

            // Assert
            Assert.That(availablePointsAfterDistribution, Is.EqualTo(availablePointsBeforeDistribution + pointsToBeAdded));

        }
        finally
        {
            await _webUserDataAccess.DeleteWebUserAsync(_secondUserDto.Id);
            await _challangeFacadeApiClient.ClearTempTableBeforeNextChallengeAsync();
        }

    }

    [Test]
    public async Task TestingGetChallengeQuizReturnsAQuizDtoWithSixteenQuestions()
    {
        List<int> questionIds = new List<int>();
        List<int> answerIds = new List<int>();
        try
        {
            // Arrange
            CreateCourse();
            var courseId = await _courseDataAccess.InsertCourseAsync(_courseToInsert);
            _courseToInsert.Id = courseId;

            CreateSubject();
            _subjectToInsert.FKCourseId = courseId;
            var subjectId = await _subjectDataAccess.InsertSubjectAsync(_subjectToInsert);
            _subjectToInsert.Id = subjectId;

            CreateChapter();
            _chapterToInsert.FKSubjectId = subjectId;
            var chapterId = await _chapterDataAccess.InsertChapterAsync(_chapterToInsert);
            _chapterToInsert.Id = chapterId;

            Question[] questions = new Question[20];
            Answer[] answers = new Answer[80];

            for (int i = 0; i < questions.Length; i++)
            {
                questions[i] = new Question()
                {
                    QuestionText = $"Question {i}",
                    FKChapterId = _chapterToInsert.Id
                };

                var questionId = await _questionDataAccess.InsertQuestionAsync(questions[i]);
                questionIds.Add(questionId);

                for (int j = 0; j < 4; j++)
                {
                    answers[j] = new Answer()
                    {
                        FKQuestionId = questions[i].Id,
                        IsCorrect = j == 2 ? "yes" : "no",
                        AnswerText = $"AnswerText {i + 1} - {j}"
                    };

                    var answerId = await _answerDataAccess.InsertAnswerAsync(answers[j]);
                    answerIds.Add(answerId);
                }
            }

            // Act
            var quizDto = await _challangeFacadeApiClient.GetChallengeQuizAsync(_courseToInsert.ToDto());

            // Assert
            Assert.That(quizDto.QuizQuestions.Any, Is.True);
        }
        finally
        {
            foreach (var id in questionIds)
            {
                await _questionDataAccess.DeleteQuestionAsync(id);
            }

            foreach (var id in answerIds)
            {
                await _answerDataAccess.DeleteAnswerAsync(id);
            }

            await _chapterDataAccess.DeleteChapterAsync(_chapterToInsert.Id);
            await _subjectDataAccess.DeleteSubjectAsync(_subjectToInsert.Id);
            await _courseDataAccess.DeleteCourseAsync(_courseToInsert.Id);

        }
    }

    private void CreateCourse()
    {
        _courseToInsert = new Course()
        {
            Name = "CourseName",
            Description = "CourseDescription"
        };

    }

    private void CreateSubject()
    {
        _subjectToInsert = new Subject()
        {
            Name = "SubjectName",
            Description = "SubjectDescription"
        };

    }

    private void CreateChapter()
    {
        _chapterToInsert = new Chapter()
        {
            Name = "ChapterName",
            Description = "ChapterDescription"
        };

    }

}
