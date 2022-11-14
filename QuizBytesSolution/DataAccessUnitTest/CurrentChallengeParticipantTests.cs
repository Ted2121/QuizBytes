using SQLAccessImplementationLibrary;
using DataAccessDefinitionLibrary.Data_Access_Models;
using NUnit.Framework;
using System;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using SQLAccessImplementationLibraryUnitTest;
using Assert = NUnit.Framework.Assert;

namespace DataAccessUnitTest
{
[TestFixture]
public class CurrentChallengeParticipantTests
{
    WebUser? _user;
    Course? _course;
    Random? _random;

    ICurrentChallengeParticipantDataAccess ?_currentChallengeParticipantDataAccess;

    [SetUp]
    public async Task SetUp()
    {
        _random = new Random();
        int randomId = _random.Next(1, 500);
        int randomTotalPoints = _random.Next(1, 500);
        int randomAvailablePoints = _random.Next(1, 500);

        _user = new WebUser(randomId, "testusername", "testpassword", "testemail", randomTotalPoints, randomAvailablePoints);
        _course = new Course("testname", "testdescription");

        _currentChallengeParticipantDataAccess = new CurrentChallengeParticipantDataAccessMock(Configuration.CONNECTION_STRING);

           
    }

[TearDown]
    public async Task TearDown()
    {
        await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
    }

    [Test]
    public async Task TestUserLimitBlockOnInsertAttemptWithRandomUserIds()
    {

        // Arrange
        await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
            //int randomId = _random.Next(1, 500); -- commented out because it is unused.
            //has to be empty and if this is the first test to run we cannot ensure that without adding this line

            // sadly logic cannot be avoided in this test as we need to create 100 users to reach the challenge limit
            WebUser[] webUsers = new WebUser[100];
        for (int i = 0; i < webUsers.Length; i++)
        {
            // we only care about it for the challenge test
            webUsers[i] = new WebUser(i); //replaced the randomId with i, ensures no duplicates.
            await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(webUsers[i], _course);
        }

        // Act
            
        var insertion = () =>  _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(_user, _course);
            // Assert

            Assert.ThrowsAsync<Exception>(async () => await insertion()) ;

    }
    [Test]
    public async Task TestInsertMethodPositiveExpectation()
    {
        //Arrange
        int randomTestId = 1;
        _user.PKWebUserId = randomTestId;
        _course.PKCourseId = randomTestId;
        var expected = _user.PKWebUserId; 

        //Act
        var actual = await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(_user, _course);

        //Assert
        Assert.AreEqual(expected, actual);
    }
[Test]
    public async Task TestDeleteWithExistingUser() // not sure if we want to test for non existing users or not, that's why I added the "WithExisting" part
    {
        //Arrange is done in SetUp
        await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(_user, _course);
        //act
        bool deleted = await _currentChallengeParticipantDataAccess.DeleteWebUserFromChallengeAsync(_user.PKWebUserId);

        //Assert
        Assert.That(deleted, Is.True);
    }
}
}