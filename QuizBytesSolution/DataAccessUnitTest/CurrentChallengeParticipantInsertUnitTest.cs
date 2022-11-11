using SQLAccessImplementationLibrary;
using DataAccessDefinitionLibrary.Data_Access_Models;

namespace DataAccessUnitTest
{
    [TestClass]
    public class CurrentChallengeParticipantInsertUnitTest
    {
        [TestMethod]
        public async void TestUserLimitBlockOnInsertAttempt()
        {
            int rowAmountToTest = 100;
            int expected = 0;
            int randomId = 1;
            int randomTotalPoints = 0;
            int randomAvailablePoints = 0;
            WebUser user = new("username","password","email",randomTotalPoints,randomAvailablePoints,randomId);
            Course course = new(randomId,"name","description");
            //fml this won't work, im tired so i'll work on it more tomorrow...
            //won't work even without parameters
            var actual = await CurrentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(user,course,rowAmountToTest);

            Assert.AreEqual(expected, actual);
        }
    }
}