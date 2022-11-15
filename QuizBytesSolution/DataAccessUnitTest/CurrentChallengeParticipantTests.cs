using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using NUnit.Framework;
using SQLAccessImplementationLibraryUnitTest;
using Assert = NUnit.Framework.Assert;

namespace DataAccessUnitTest
{
    [TestFixture]
    public class CurrentChallengeParticipantTests
    {
        private WebUser? _user;
        private Course? _course;
        private Random? _random;
        private ICurrentChallengeParticipantDataAccess? _currentChallengeParticipantDataAccess;

        [SetUp]
        public void SetUp()
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

            WebUser[] webUsers = new WebUser[100];
            for (int i = 0; i < webUsers.Length; i++)
            {
                webUsers[i] = new WebUser(i + 1);
                await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(webUsers[i], _course);
            }

            // Act & Assert

            Assert.That(async () => await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(_user, _course), Throws.Exception);

            await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();

        }

        [Test]
        public async Task TestInsertMethodPositiveExpectation()
        {
            //Arrange
            await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
            int randomTestId = 1;
            _user.PKWebUserId = randomTestId;
            _course.PKCourseId = randomTestId;
            var expected = _user.PKWebUserId;

            //Act
            var actual = await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(_user, _course);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));

            await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
        }

        [Test]
        public async Task TestDeleteWithExistingUser() // not sure if we want to test for non existing users or not, that's why I added the "WithExisting" part
        {
            //Arrange
            await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
            await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(_user, _course);

            //act
            bool deleted = await _currentChallengeParticipantDataAccess.DeleteWebUserFromChallengeAsync(_user.PKWebUserId);

            //Assert
            Assert.That(deleted, Is.True);

            await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
        }
    }
}