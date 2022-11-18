using DataAccessDefinitionLibrary.DAO_Interfaces;
using SQLAccessImplementationLibrary;
using SQLAccessImplementationLibraryUnitTest;
using WebApiClient;
using WebApiClient.DTOs;

namespace WebclientWebserverIntegrationTesting
{
    [TestFixture]
    public class ChallengeControllerTests
    {
        private IChallengeFacadeApiClient _challangeFacadeApiClient = new ChallengeFacadeApiClient(Configuration.WEB_API_URI);
        private IWebUserFacadeApiClient _webUserFacadeApiClient = new WebUserFacadeApiClient(Configuration.WEB_API_URI);
        private IWebUserDataAccess _webUserDataAccess = new WebUserDataAccess(Configuration.CONNECTION_STRING);
        private ICourseDataAccess _courseDataAccess = new CourseDataAccess(Configuration.CONNECTION_STRING);
        private WebUserDto _userDto;
        private CourseDto _courseDto;
        private CurrentChallengeParticipantDto _currentChallengeParticipantDto;
        private ICurrentChallengeParticipantDataAccess _currentChallengeParticipantDataAccess = new CurrentChallengeParticipantDataAccessMock();

        public WebUserDto WebUserDto { get; set; }

        private async Task<WebUserDto> CreateAndInsertNewWebUserAsync()
        {
            _userDto = new WebUserDto()
            {
                Username = "Bob",
                PasswordHash = "BobProtecc",
                Email = "bob@Bob.com",
                TotalPoints = 453,
                AvailablePoints = 200,
                NumberOfCorrectAnswers = 4,
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

        //private async Task InsertCurrentChallengeParticipant()
        //{
        //    await _challangeFacadeApiClient.Reg
        //}



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
                await _challangeFacadeApiClient.DeregisterParticipantAsync(_userDto.Id);
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
                await _challangeFacadeApiClient.DeregisterParticipantAsync(_userDto.Id);
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
    }
}
