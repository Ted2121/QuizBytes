using DataAccessDefinitionLibrary.Data_Access_Models;
using NUnit.Framework;
using SQLAccessImplementationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace SQLAccessImplementationLibraryUnitTest;

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

    }

    [TearDown]
    public async Task TearDownAsync()
    {
        await _webUserDataAccess.DeleteWebUserAsync(_webUser.Id);
    }

    [Test]
    public async Task TestingUpdateExpectingPropertiesChangedInDB()
    {
        // Arrange

        _webUser.Id = await _webUserDataAccess.InsertWebUserAsync(_webUser);
        var newUsername = "Fredderick";
        _webUser.Username = newUsername;

        // Act
        var test = await _webUserDataAccess.UpdateWebUserAsync(_webUser);
        var userFromDb = await _webUserDataAccess.GetWebUserByIdAsync(_webUser.Id);
        var usernameFromDb = userFromDb.Username;

        // Assert
        Assert.That(usernameFromDb, Is.EqualTo(newUsername));
        //Assert.That(test, Is.True);
    }

    [Test]
    public async Task TestingInsertionExpectingPositiveResult()
    {
        // Arrange in setup

        // Act
        _webUser.Id = await _webUserDataAccess.InsertWebUserAsync(_webUser);

        // Assert
        Assert.That(_webUser.Id, Is.GreaterThan(0));
    }

    [Test]
    public async Task TestingInsertionWithoutUsernameExpectingException()
    {
        // Arrange
        _webUser.Username = null;

        // Act & Assert
        Assert.That(async () => await _webUserDataAccess.InsertWebUserAsync(_webUser), Throws.Exception);
    }

    [Test]
    public async Task TestingGettingWebUserByUsernameExpectingUserNotNull()
    {
        // Arrange
        await _webUserDataAccess.InsertWebUserAsync(_webUser);

        // Act
        var userReturned = await _webUserDataAccess.GetWebUserByUsernameAsync(_webUser.Username);

        // Assert
        Assert.That(userReturned, Is.Not.Null);
    }

    [Test]
    public async Task TestingGettingWebUserByInexistentUsernameExpectingNull()
    {
        // Arrange
        await _webUserDataAccess.InsertWebUserAsync(_webUser);
        var inexistentUsername = "bhfjvsdbfvhjbdsvhbfdsvbhfbvhbfdsvbfbvbfvbfhjdb";
        // Act
        var user = await _webUserDataAccess.GetWebUserByUsernameAsync("bhfjvsdbfvhjbdsvhbfdsvbhfbvhbfdsvbfbvbfvbfhjdb");

        // Assert
        Assert.That(user , Is.Null);
    }

    [Test]
    public async Task TestingGettingWebUserByIdExpectingUserNotNull()
    {
        // Arrange
        await _webUserDataAccess.InsertWebUserAsync(_webUser);

        // Act
        var userReturned = await _webUserDataAccess.GetWebUserByIdAsync(_webUser.Id);

        // Assert
        Assert.That(userReturned, Is.Not.Null);
    }

    [Test]
    public async Task TestingGettingWebUserByInexistentIdExpectingNull()
    {
        // Arrange
        await _webUserDataAccess.InsertWebUserAsync(_webUser);
        // Act
        var user = await _webUserDataAccess.GetWebUserByIdAsync(0);

        // Assert
        Assert.That(user, Is.Null);
    }

    [Test]
    public async Task TestingGettingAllWebUsersExpectingAnyReturned()
    {
        // Arrange
        await _webUserDataAccess.InsertWebUserAsync(_webUser);

        // Act
        var usersReturned = await _webUserDataAccess.GetAllWebUsersAsync();

        // Assert
        Assert.That(usersReturned.Any(), Is.True);
    }

    [Test]
    public async Task TestingDeleteWebUserExpectingTrue()
    {
        // Arrange
        await _webUserDataAccess.InsertWebUserAsync(_webUser);

        // Act
        var deleted = await _webUserDataAccess.DeleteWebUserAsync(_webUser.Id);

        // Assert
        Assert.That(deleted, Is.True);
    }

    [Test]
    public async Task TestingDeleteInexistentWebUserExpectingFalse()
    {
        // Arrange - no insertion

        // Act
        var deleted = await _webUserDataAccess.DeleteWebUserAsync(_webUser.Id);

        // Assert
        Assert.That(deleted, Is.False);
    }

    [Test]
    public async Task TestingUpdatePasswordExpectingTrue()
    {
        // Arrange
        await _webUserDataAccess.InsertWebUserAsync(_webUser);

        // Act
        var updated = await _webUserDataAccess.UpdatePasswordAsync(_webUser.Username, _webUser.PasswordHash, "newTestPassword");

        // Assert
        Assert.That(updated, Is.True);

    }

    [Test]
    public async Task TestingLoginExpectingLoggedInUserReturned()
    {
        // Arrange
        await _webUserDataAccess.InsertWebUserAsync(_webUser);

        // Act
        var user = await _webUserDataAccess.LoginAsync(_webUser.Username, _webUser.PasswordHash);

        // Assert
        Assert.That(user, Is.Not.Null);
    }

    [Test]
    public async Task TestingLoginWithIncorrectDetailsExpectingException()
    {
        // Arrange
        await _webUserDataAccess.InsertWebUserAsync(_webUser);

        // Act & Assert
        Assert.That(async () => await _webUserDataAccess.LoginAsync(_webUser.Username, "incorrectpassword"), Throws.Exception);
    }
}
