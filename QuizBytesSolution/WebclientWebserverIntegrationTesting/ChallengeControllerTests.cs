using DataAccessDefinitionLibrary.DAO_Interfaces;
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
        IWebUserDataAccess _webUserDataAccess;
        ICourseDataAccess _courseDataAccess;
        WebUserDto _userDto;
        CourseDto _courseDto;
        CurrentChallengeParticipantDto _currentChallengeParticipantDto;

        public WebUserDto WebUserDto { get; set; }

        private async Task<WebUserDto> CreateNewWebUserAsync()
        {
            _userDto = new WebUserDto()
            {
                Username = "Bob",
                Password = "BobProtecc",
                Email = "bob@Bob.com",
                TotalPoints = 453,
                AvailablePoints = 200,
                NumberOfCorrectAnswers = 4,
            };
            _userDto.Id = await _webUserDataAccess.InsertWebUserAsync(_userDto.FromDto());

            return _userDto;
        }

        private async Task<CourseDto> CreateNewCourseAsync()
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
            _currentChallengeParticipantDto = new CurrentChallengeParticipantDto()
            {
                WebUser = await CreateNewWebUserAsync(),
                Course = await CreateNewCourseAsync()
            };

            return _currentChallengeParticipantDto;
        }

        [SetUp]
        public async Task SetUpAsync()
        {
            
        }

        [TearDown]
        public async Task CleanUpAsync()
        {

        }
        
    }
}
