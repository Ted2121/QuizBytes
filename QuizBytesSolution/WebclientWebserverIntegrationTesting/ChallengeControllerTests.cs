﻿using System;
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
        WebUserFacadeApiClient _webUserFacadeApiClient = new WebUserFacadeApiClient(Configuration.WEB_API_URI);
        WebUserDto _userDto;
        CourseDto _courseDto;

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
            _userDto.Id = await _challangeFacadeApiClient.RegisterParticipantAsync(_userDto, _courseDto);

            return _userDto;
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
