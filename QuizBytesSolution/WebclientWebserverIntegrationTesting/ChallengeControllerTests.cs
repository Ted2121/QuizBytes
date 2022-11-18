using DataAccessDefinitionLibrary.DAO_Interfaces;
using SQLAccessImplementationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.DTOs;

namespace WebclientWebserverIntegrationTesting
{
    [TestFixture]
    public class ChallengeControllerTests
    {
        IChallengeFacadeApiClient _challangeFacadeApiClient = new ChallengeFacadeApiClient(Configuration.WEB_API_URI);
        IWebUserFacadeApiClient _webUserFacadeApiClient = new WebUserFacadeApiClient(Configuration.WEB_API_URI);
        IWebUserDataAccess _webUserDataAccess = new WebUserDataAccess(Configuration.CONNECTION_STRING);
        ICourseDataAccess _courseDataAccess = new CourseDataAccess(Configuration.CONNECTION_STRING);
        WebUserDto _userDto;
        CourseDto _courseDto;
        CurrentChallengeParticipantDto _currentChallengeParticipantDto;

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
                //await _challangeFacadeApiClient.DeregisterParticipantAsync(_userDto.Id);
            }

        }

        [Test]
        public async Task CheckingNumberOfParticipants()
        {
            try
            {
            // Arrange
            //_challangeFacadeApiClient.RegisterParticipantAsync(_userDto, _courseDto);

            // Assert
            var numberOfParticipantsAfterRegistration = await _challangeFacadeApiClient.GetNumberOfParticipantsAsync();

            // Act
            Assert.That(numberOfParticipantsAfterRegistration, Is.EqualTo(1));

            }
            finally
            {
                //await _challangeFacadeApiClient.DeregisterParticipantAsync(_userDto.Id);
            }
        }
        
    }
}
