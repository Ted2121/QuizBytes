using DataAccessDefinitionLibrary.Data_Access_Models;
using NUnit.Framework;
using SQLAccessImplementationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace SQLAccessImplementationLibraryUnitTest
{
    [TestFixture]
    public class WebUserDataAccessTests
    {
        WebUserDataAccess _webUserDataAccess = new WebUserDataAccess(Configuration.CONNECTION_STRING);
        WebUser _webUser;

        [SetUp]
        public async Task SetUpAsync()
        {
            _webUser = new WebUser()
            {
                Username = "Bob",
                PasswordHash = "BobProtecc",
                Email = "bob@Bob.com",
                TotalPoints = 0,
                AvailablePoints = 0,
            };

            await _webUserDataAccess.InsertWebUserAsync(_webUser);
        }

        [TearDown]
        public async Task TearDownAsync()
        {
            await _webUserDataAccess.DeleteWebUserAsync(_webUser.PKWebUserId);
        }

        [Test]
        public async Task TestingUpdateExpectingPropertiesChangedInDB()
        {
            // Arrange
            var newUsername = "Fredderick";
            _webUser.Username = newUsername;

            // Act
            var test = await _webUserDataAccess.UpdateWebUserAsync(_webUser);
            var userFromDb = await _webUserDataAccess.GetWebUserByIdAsync(_webUser.PKWebUserId);
            var usernameFromDb = userFromDb.Username;

            // Assert
            Assert.That(usernameFromDb, Is.EqualTo(newUsername));
            //Assert.That(test, Is.True);
        }


    }
}
