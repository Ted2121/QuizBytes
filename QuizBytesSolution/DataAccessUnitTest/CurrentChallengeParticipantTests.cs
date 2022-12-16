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
        public async Task SetUpAsync()
        {
            _random = new Random();
            int randomId = _random.Next(101, 500);
            int randomTotalPoints = _random.Next(1, 500);
            int randomAvailablePoints = _random.Next(1, 500);

            _user = new WebUser("testusername", "testpassword", "testemail", randomTotalPoints, randomAvailablePoints);
            _course = new Course("testname", "testdescription");

            _currentChallengeParticipantDataAccess = new CurrentChallengeParticipantDataAccessMock();

        }

        [TearDown]
        public async Task TearDownAsync()
        {
            await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
        }

        [Test]
        public async Task TestingThatAddingAUserOverTheLimitForTheChallengeThrowsException()
        {

            try
            {
                // Arrange
                await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();

                WebUser[] webUsers = new WebUser[10];
                for (int i = 0; i < webUsers.Length; i++)
                {
                    webUsers[i] = new WebUser(i + 1);
                    await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(webUsers[i], _course);
                }

                // Act & Assert

                Assert.That(async () => await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(_user, _course), Throws.Exception);
            }
            finally
            {
                await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();

            }

        }

        [Test]
        public async Task TestingThatTransactionIsRolledBack()
        {
            // Arrange
            await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();

            WebUser[] webUsers = new WebUser[1];
            for (int i = 0; i < webUsers.Length; i++)
            {
                webUsers[i] = new WebUser(i + 1);
                await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(webUsers[i], _course);
            }
            var userCountBeforeLastTransaction = await _currentChallengeParticipantDataAccess.GetRowAmountFromDatabaseAsync();


            await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(_user, _course);

            // Act
            var userCountAfterLastTransaction = await _currentChallengeParticipantDataAccess.GetRowAmountFromDatabaseAsync();

            // Assert
            Assert.That(userCountBeforeLastTransaction, Is.EqualTo(userCountAfterLastTransaction));
        }

        [Test]
        public async Task TestInsertMethodPositiveExpectationAsync()
        {
            try
            {
                //Arrange
                await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
                int randomTestId = 1;
                _user.Id = randomTestId;
                _course.Id = randomTestId;
                var expected = _user.Id;

                //Act
                var actual = await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(_user, _course);

                //Assert
                Assert.That(actual, Is.EqualTo(expected));
            }
            finally
            {
                await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();

            }

        }

        [Test]
        public async Task TestDeleteWithExistingUser() // not sure if we want to test for non existing users or not, that's why I added the "WithExisting" part
        {
            try
            {
                //Arrange
                await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
                await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(_user, _course);

                //Act
                bool deleted = await _currentChallengeParticipantDataAccess.DeleteWebUserFromChallengeAsync(_user.Id);

                //Assert
                Assert.That(deleted, Is.True);
            }
            finally
            {

                await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
            }

        }

        [Test]
        public async Task CheckingIfWebUserIsInChallengeExpectingFalseAsync()
        {
            //Arrange
            await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();

            //Act
            var actual = await _currentChallengeParticipantDataAccess.CheckIfWebUserIsInChallengeAsync(_user.Id);

            // Assert

            Assert.That(actual, Is.False);


        }

        [Test]
        public async Task CheckingIfWebUserIsInChallengeExpectingTrueAsync()
        {
            try
            {
                //Arrange
                await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
                await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(_user, _course);

                //Act
                var actual = await _currentChallengeParticipantDataAccess.CheckIfWebUserIsInChallengeAsync(_user.Id);

                // Assert
                Assert.That(actual, Is.True);
            }
            finally
            {
                await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();

            }

        }

        [Test]
        public async Task TestingIfCorrectRowAmountIsReturnedAsync()
        {
            try
            {
                // Arrange
                await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
                await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(_user, _course);

                // Act
                var actual = await _currentChallengeParticipantDataAccess.GetRowAmountFromDatabaseAsync();

                // Assert
                Assert.That(actual, Is.EqualTo(1));
            }
            finally
            {

                await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
            }
        }

        [Test]
        public async Task TestingIfClearingTheTableWorksAsync()
        {
            // Arrange
            await _currentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(_user, _course);


            // Act
            var actual = await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();

            // Assert
            Assert.That(actual, Is.EqualTo(true));
        }
    }
}