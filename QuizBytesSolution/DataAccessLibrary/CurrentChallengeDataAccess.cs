using Dapper;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System.Data.SqlClient;

namespace SQLAccessImplementationLibrary
{
    public class CurrentChallengeDataAccess : BaseDataAccess, ICurrentChallengeDataAccess
    {
        public CurrentChallengeDataAccess(string connectionstring) : base(connectionstring)
        {

        }

        public async Task<int> AddWebUserToChallengeAsync(WebUser webUser, Course course)
        {
            try
            {
                string commandText = "INSERT INTO CurrentChallenge (FKWebUserId, FKCourseId) VALUES (@FKWebUserId, @FKCourseId); SELECT CAST(scope_identity() AS int)";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        FKWebUserId = webUser.PKWebUserId,
                        FKCourseId = course.PKCourseId
                    };

                    await connection.ExecuteAsync(commandText, parameters);
                    var currentChallengeRowId = (int)await connection.ExecuteScalarAsync(commandText, parameters);
                    return currentChallengeRowId;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to insert into CurrentChallenge table. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<IEnumerable<CurrentChallenge>> GetAllRowsInChallengeAsync()
        {
            try
            {
                string commandText = "SELECT * FROM CurrentChallenge";
                using (SqlConnection connection = CreateConnection())
                {

                    var challengeRows = await connection.QueryAsync<CurrentChallenge>(commandText);

                    return challengeRows;
                }
            }
            catch (SqlException ex)
            {

                throw new($"Exception while trying to retrieve all rows from CurrentChallenge table. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<bool> DeleteWebUserFromChallengeAsync(int webUserId)
        {
            try
            {
                string commandText = "DELETE FROM CurrentChallenge WHERE FKWebUserId = @FKWebUserId";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        FKWebUserId = webUserId
                    };

                    return await connection.ExecuteAsync(commandText, parameters) > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to delete a row from CurrentChallenge table. The exception was: '{ex.Message}'", ex);

            }
        }

        // We do this reset because the CurrentChallenge table is a temporary table and only needs to hold data to populate the leaderboard at the end of the challenge
        public async Task ClearTempTableBeforeNextChallengeAsync()
        {
            try
            {
                string commandText = "DELETE FROM CurrentChallenge";
                using (SqlConnection connection = CreateConnection())
                {
                    await connection.ExecuteAsync(commandText);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to delete contents of CurrentChallenge table. The exception was: '{ex.Message}'", ex);

            }
        }
    }
}
