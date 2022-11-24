using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using SQLAccessImplementationLibrary;
using SQLAccessImplementationLibraryUnitTest;
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
    public class WebUserFacadeTests
    {
        private IWebUserFacadeApiClient _webUserFacadeApiClient = new WebUserFacadeApiClient(Configuration.WEB_API_URI);

        private IWebUserDataAccess _webUserDataAccess = new WebUserDataAccess(Configuration.CONNECTION_STRING);

        private WebUserDto _userDto;
        private WebUserDto _secondUserDto;

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
    }
}
