using SQLAccessImplementationLibrary;
using DataAccessDefinitionLibrary.Data_Access_Models;
using NUnit.Framework;
using System;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using SQLAccessImplementationLibraryUnitTest;

namespace DataAccessUnitTest
{
    [TestFixture]
    public class CurrentChallengeParticipantTests
    {
        WebUser? _user;
        Course? _course;
        Random _random;

        IWebUserDataAccess _webUserDataAccess;
        ICourseDataAccess _courseDataAccess;

        [SetUp]
        public void SetUp()
        {
            int randomId = _random.Next(1, 500);
            int randomTotalPoints = _random.Next(1, 500);
            int randomAvailablePoints = _random.Next(1, 500);

            _user = new WebUser(randomId, "testusername", "testpassword", "testemail", randomTotalPoints, randomAvailablePoints);
            _course = new Course("testname", "testdescription");
            _random = new Random();

            _webUserDataAccess = new WebUserDataAccess(Configuration.CONNECTION_STRING);

        }

        [Test]
        public async Task TestUserLimitBlockOnInsertAttempt()
        {

            int expected = 0;
           
            
            //fml this won't work, im tired so i'll work on it more tomorrow...
            //won't work even without parameters
            var actual = await CurrentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(user,course);

            Assert.AreEqual(expected, actual);
        }
    }
}