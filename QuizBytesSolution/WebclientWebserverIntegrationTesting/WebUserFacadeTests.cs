using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using SQLAccessImplementationLibrary;
using WebApiClient;
using WebApiClient.DTOs;

namespace WebclientWebserverIntegrationTesting;

[TestFixture]
public class WebUserFacadeTests
{
    private IWebUserFacadeApiClient _webUserFacadeApiClient = new WebUserFacadeApiClient(Configuration.WEB_API_URI);
    private ChapterFacadeApiClient _chapterFacade = new ChapterFacadeApiClient(Configuration.WEB_API_URI);
    private ICourseDataAccess _courseDataAccess = new CourseDataAccess(Configuration.CONNECTION_STRING);
    private ISubjectDataAccess _subjectDataAccess = new SubjectDataAccess(Configuration.CONNECTION_STRING);
    private IWebUserDataAccess _webUserDataAccess = new WebUserDataAccess(Configuration.CONNECTION_STRING);
    private IChapterDataAccess _chapterDataAccess = new ChapterDataAccess(Configuration.CONNECTION_STRING);
    private IWebUserChapterUnlockDataAccess _chapterUnlockDataAccess = new WebUserChapterUnlockDataAccess(Configuration.CONNECTION_STRING);


    private WebUserDto? _userDto;
    private WebUserDto? _secondUserDto;
    private WebUserChapterUnlock chapterUnlockModel = null;
    private int chapterId = 0;
    private int courseId = 0;
    private int subjectId = 0;
    private int chapterPrice = 64;

    private async Task<WebUserDto> CreateAndInsertNewWebUserAsync()
    {
        _userDto = new WebUserDto()
        {
            Username = "Bob",
            PasswordHash = "BobProtecc",
            Email = "bob@Bob.com",
            TotalPoints = 0,
            AvailablePoints = 64,
            NumberOfCorrectAnswers = 4
        };
        _userDto.Id = await _webUserDataAccess.InsertWebUserAsync(_userDto.FromDto());

        return _userDto;
    }


    [SetUp]
    public async Task SetUpAsync() => await CreateAndInsertNewWebUserAsync();

    [TearDown]
    public async Task CleanUpAsync()
    {
        await _webUserDataAccess.DeleteWebUserAsync(_userDto.Id);
    }

    [Test]
    public async Task TestingLoginExpectingSuccess()
    {
        // Arrange in SetUp

        // Act
        var user = await _webUserFacadeApiClient.LoginUserAsync(_userDto);

        // Assert
        Assert.That(user, Is.Not.Null);
    }

    [Test]
    public async Task CreatingWebUserExpectingPositiveResult()
    {
        int userId = 0;
        try
        {
            // Arrange
            WebUserDto testWebUser = new()
            {
                Username = "testuser",
                PasswordHash = "testpass",
                Email = "test@test"
            };

            // Act
            userId = await _webUserFacadeApiClient.CreateWebUserAsync(testWebUser);

            // Assert
            Assert.That(userId, Is.GreaterThan(0));
        }
        finally
        {
            await _webUserDataAccess.DeleteWebUserAsync(userId);
        }
    }

    [Test]
    public async Task CreatingWebUserWithoutUsernameExpectingException()
    {

        int userId = 0;
        try
        {
            // Arrange
            WebUserDto testWebUser2 = new()
            {
                PasswordHash = "test",
                Email = "test@test"
            };
            // Act

            // Assert
            Assert.That(async () => userId = await _webUserFacadeApiClient.CreateWebUserAsync(testWebUser2), Throws.Exception);

        }
        finally
        {
            if (userId != 0)
            {
                await _webUserDataAccess.DeleteWebUserAsync(userId);
            }
        }
    }

    [Test]
    public async Task TestingDeleteWebUserExpectingPositiveResult()
    {
        // Arrange in set up


        // Act
        var deleted = await _webUserFacadeApiClient.DeleteWebUserAsync(_userDto.Id);

        // Assert
        Assert.That(deleted, Is.True);
    }

    [Test]
    public async Task TestingDeleteWebUserThatDoesntExistExpectingException()
    {
        // Arrange
        await _webUserDataAccess.DeleteWebUserAsync(_userDto.Id);

        // Act & Assert
        Assert.That(async () => await _webUserFacadeApiClient.DeleteWebUserAsync(_userDto.Id), Throws.Exception);
    }

    [Test]
    public async Task TestingGettingAllWebUsersExpectingAnyUserRetrieved()
    {
        // Arrange in setup

        // Act
        var users = await _webUserFacadeApiClient.GetAllWebUsersAsync();

        // Assert
        Assert.That(users.Any(), Is.True);
    }

    [Test]
    public async Task TestingUnlockingChapterForAUserExpectingPositiveResult()
    {
        try
        {
            // Arrange
            await CreateAndInsertObjectsAsync();
            var chapterDto = await _chapterFacade.GetChapterByIdAsync(chapterId);

            WebUserChapterUnlockDto chapterUnlock = new()
            {
                WebUserDto = _userDto,
                ChapterDto = chapterDto
            };

            chapterUnlockModel = new()
            {
                FKChapterId = chapterId,
                FKWebUserId = _userDto.Id
            };

            // Act
            var unlocked = await _webUserFacadeApiClient.UnlockChapterAsync(chapterUnlock);

            // Assert
            Assert.That(unlocked, Is.True);
        }
        finally
        {
            await CleanUpAfterUnlockingChapters();
        }
    }

    [Test]
    public async Task TestingThatUnlockingAChapterFailsIfTheUserDoesntHaveEnoughAvailablePoints()
    {
        try
        {
            // Arrange
            await CreateAndInsertObjectsAsync();
            var chapterDto = await _chapterFacade.GetChapterByIdAsync(chapterId);
            _userDto.AvailablePoints = chapterPrice - 1;

            WebUserChapterUnlockDto chapterUnlock = new()
            {
                WebUserDto = _userDto,
                ChapterDto = chapterDto
            };

            chapterUnlockModel = new()
            {
                FKChapterId = chapterId,
                FKWebUserId = _userDto.Id
            };

            // Act & Assert
            Assert.That(async () => await _webUserFacadeApiClient.UnlockChapterAsync(chapterUnlock), Throws.Exception);
        }
        finally
        {
            await CleanUpAfterUnlockingChapters();
        }
    }


    [Test]
    public async Task TestingThatAvailablePointsAreDeductedFromTheUserOnChapterUnlock()
    {
        try
        {
            // Arrange
            await CreateAndInsertObjectsAsync();
            var chapterDto = await _chapterFacade.GetChapterByIdAsync(chapterId);

            WebUserChapterUnlockDto chapterUnlock = new()
            {
                WebUserDto = _userDto,
                ChapterDto = chapterDto
            };

            chapterUnlockModel = new()
            {
                FKChapterId = chapterId,
                FKWebUserId = _userDto.Id
            };

            // Act
            var initialPoints = _userDto.AvailablePoints;
            await _webUserFacadeApiClient.UnlockChapterAsync(chapterUnlock);
            var userAfterUnlock = await _webUserFacadeApiClient.GetWebUserByIdAsync(_userDto.Id);
            var pointsAfterUnlock = userAfterUnlock.AvailablePoints;
            // Assert
            Assert.That(pointsAfterUnlock, Is.EqualTo(initialPoints - chapterPrice));
        }
        finally
        {
            await CleanUpAfterUnlockingChapters();
        }
    }

    [Test]
    public async Task TestingGettingUserByIdExpectingPositiveResult()
    {
        // Arrange in setup


        // Act
        var userDto = await _webUserFacadeApiClient.GetWebUserByIdAsync(_userDto.Id);

        // Assert
        Assert.That(userDto, Is.Not.Null);
    }

    [Test]
    public async Task TestingLoggingInWithCorrectDetailsExpectingPositiveResults()
    {
        // Arrange in setup

        // Act
        var userReturnedByLogin = await _webUserFacadeApiClient.LoginUserAsync(_userDto);

        // Assert
        Assert.That(_userDto.Id, Is.EqualTo(userReturnedByLogin.Id));
    }

    [Test]
    public async Task TestingLoggingInWithWrongDetailsExpectingException()
    {
        // Arrange
        _userDto.PasswordHash = "wrongPass";

        // Act & Assert
        Assert.That(async () => await _webUserFacadeApiClient.LoginUserAsync(_userDto), Throws.Exception);
    }

    [Test]
    public async Task TestingThatGettingUnlockedChaptersOfAUserReturnsAChapter()
    {
        try
        {
            // Arrange
            await CreateAndInsertObjectsAsync();
            var chapterDto = await _chapterFacade.GetChapterByIdAsync(chapterId);

            WebUserChapterUnlockDto chapterUnlock = new()
            {
                WebUserDto = _userDto,
                ChapterDto = chapterDto
            };

            chapterUnlockModel = new()
            {
                FKChapterId = chapterId,
                FKWebUserId = _userDto.Id
            };
            await _webUserFacadeApiClient.UnlockChapterAsync(chapterUnlock);

            // Act
            var unlockedChapters = await _webUserFacadeApiClient.GetUnlockedChaptersOfWebUserAsync(_userDto.Id);

            // Assert
            Assert.That(unlockedChapters.Any(), Is.True);
        }
        finally
        {
            await CleanUpAfterUnlockingChapters();
        }
    }


    private async Task CreateAndInsertObjectsAsync()
    {
        Course course = new Course()
        {
            Name = "TestCourse",
            Description = "test"
        };
        courseId = await _courseDataAccess.InsertCourseAsync(course);

        Subject subject = new Subject()
        {
            Name = "TestSubj",
            Description = "TestDesc",
            FKCourseId = courseId
        };
        subjectId = await _subjectDataAccess.InsertSubjectAsync(subject);

        Chapter chapter = new Chapter()
        {
            Name = "TestChapter",
            Description = "TestDescription",
            FKSubjectId = subjectId
        };
        chapterId = await _chapterDataAccess.InsertChapterAsync(chapter);
    }
    private async Task CleanUpAfterUnlockingChapters()
    {
        if (chapterUnlockModel != null)
        {
            await _chapterUnlockDataAccess.DeleteWebUserChapterUnlockAsync(chapterUnlockModel);
        }

        if (chapterId != 0)
        {
            await _chapterDataAccess.DeleteChapterAsync(chapterId);
        }

        if (subjectId != 0)
        {
            await _subjectDataAccess.DeleteSubjectAsync(subjectId);
        }

        if (courseId != 0)
        {
            await _courseDataAccess.DeleteCourseAsync(courseId);
        }
    }
}
