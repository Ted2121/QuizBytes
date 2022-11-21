using DataAccessDefinitionLibrary.DAO_Interfaces;
using QuizBytesAPIServer.Controllers;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.Factories;
using QuizBytesAPIServer.Helper_Classes;
using SQLAccessImplementationLibrary;

namespace APITests;

[TestFixture]
public class Tests
{
    IWebUserDataAccess _webUserDataAccess = new WebUserDataAccess(Configuration.CONNECTION_STRING);
    ICurrentChallengeParticipantDataAccess _currentChallengeParticipantDataAccess = new CurrentChallengeParticipantDataAccess(Configuration.CONNECTION_STRING);
    IAnswerDataAccess _answerDataAccess = new AnswerDataAccess(Configuration.CONNECTION_STRING);
    IQuestionDataAccess _questionDataAccess = new QuestionDataAccess(Configuration.CONNECTION_STRING);
    ISubjectDataAccess _subjectDataAccess = new SubjectDataAccess(Configuration.CONNECTION_STRING);
    IChapterDataAccess _chapterDataAccess = new ChapterDataAccess(Configuration.CONNECTION_STRING);
    ICourseDataAccess _courseDataAccess = new CourseDataAccess(Configuration.CONNECTION_STRING);

    IRewardsDistributionHelper _rewardsDistributionHelper; 
    IQuizFactory _quizFactory;
    IQuestionAnswerLinkFactory _questionAnswerLinkFactory;

    WebUserDto _userDto;
    WebUserDto _secondWebUserDto;
    ChallengeController _challengeController;
    CourseDto _courseDto;
    CurrentChallengeParticipantDto _firstCurrentChallengeParticipantDto;
    CurrentChallengeParticipantDto _secondCurrentChallengeParticipantDto;


    [SetUp]
    public async Task SetupAsync()
    {
        _userDto = new WebUserDto()
        {
            Username = "Bob",
            PasswordHash = "BobProtecc",
            Email = "bob@Bob.com",
            TotalPoints = 453,
            AvailablePoints = 200,
            NumberOfCorrectAnswers = 4
        };
        _userDto.Id = await _webUserDataAccess.InsertWebUserAsync(_userDto.FromDto());

        _secondWebUserDto = new WebUserDto()
        {
            Username = "Joe",
            PasswordHash = "JoeProtecc",
            Email = "joe@Bob.com",
            TotalPoints = 0,
            AvailablePoints = 0,
            NumberOfCorrectAnswers = 5
        };
        _secondWebUserDto.Id = await _webUserDataAccess.InsertWebUserAsync(_secondWebUserDto.FromDto());

        _courseDto = new CourseDto()
        {
            Name = "sys dev",
            Description = "this is a description",

        };
        _courseDto.Id = await _courseDataAccess.InsertCourseAsync(_courseDto.FromDto());

        _questionAnswerLinkFactory = new QuestionAnswerLinkFactory(_answerDataAccess, _questionDataAccess, _subjectDataAccess, _chapterDataAccess);
        _rewardsDistributionHelper = new RewardsDistributionHelper(_webUserDataAccess);
        _quizFactory = new QuizFactory(_questionAnswerLinkFactory);


        _challengeController = new ChallengeController(
            _currentChallengeParticipantDataAccess,
            _webUserDataAccess,
            _rewardsDistributionHelper,
            _quizFactory
            );

        _firstCurrentChallengeParticipantDto = new CurrentChallengeParticipantDto()
        {
            WebUser = _userDto,
            Course = _courseDto
        };

        _secondCurrentChallengeParticipantDto = new CurrentChallengeParticipantDto()
        {
            WebUser = _secondWebUserDto,
            Course = _courseDto
        };
    }

    [TearDown]
    public async Task TearDown()
    {
        await _webUserDataAccess.DeleteWebUserAsync(_userDto.Id);
        await _webUserDataAccess.DeleteWebUserAsync(_secondWebUserDto.Id);
        await _courseDataAccess.DeleteCourseAsync(_courseDto.Id);
    }

    [Test]
    public async Task TestingRewardDistribution()
    {
        // Arrange
        //await _challengeController.RegisterParticipantAsync(_firstCurrentChallengeParticipantDto);
        //await _challengeController.RegisterParticipantAsync(_secondCurrentChallengeParticipantDto);

        List<WebUserDto> leaderboard = new List<WebUserDto>()
            {
                _userDto,
                _secondWebUserDto
            };

        var availablePointsBeforeDistribution = _secondWebUserDto.AvailablePoints;

        var secondPlaceReward = 128;
        var pointsPerCorrectAnswer = 8;
        var pointsToBeAdded = (_secondWebUserDto.NumberOfCorrectAnswers * pointsPerCorrectAnswer) + secondPlaceReward;

        // Act
        await _challengeController.DistributeRewardsAsync(leaderboard);
        var availablePointsAfterDistribution = _secondWebUserDto.AvailablePoints;

        // Assert
        Assert.That(availablePointsAfterDistribution, Is.EqualTo(availablePointsBeforeDistribution + pointsToBeAdded));
    }
}