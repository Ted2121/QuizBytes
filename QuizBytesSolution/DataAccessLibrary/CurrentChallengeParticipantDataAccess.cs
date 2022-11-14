using Dapper;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System.Data;
using System.Data.SqlClient;

namespace SQLAccessImplementationLibrary
{
    public class CurrentChallengeParticipantDataAccess : BaseDataAccess, ICurrentChallengeParticipantDataAccess
    {
        
        public CurrentChallengeParticipantDataAccess(string connectionstring) : base(connectionstring)
        {

        }

        public async Task<int> AddWebUserToChallengeAsync(WebUser webUser,Course course)
        {
            int userLimitForChallenges = 100;
            var rowAmount = await GetRowAmountFromDatabaseAsync();
            if (rowAmount < userLimitForChallenges)
            {
                using (SqlConnection connection = CreateConnection())
                {
                    connection.Open();
                    IsolationLevel isolationLevel = IsolationLevel.RepeatableRead;
                    SqlTransaction transaction = connection.BeginTransaction(isolationLevel);
                    string commandText = "INSERT INTO CurrentChallengeParticipant (FKWebUserId, FKCourseId) VALUES (@FKWebUserId, @FKCourseId); SELECT CAST(scope_identity() AS int)";
                    var parameters = new
                    {
                        FKWebUserId = webUser.PKWebUserId,
                        FKCourseId = course.PKCourseId
                    };
                    try
                    {
                        await connection.ExecuteAsync(commandText, parameters);
                        transaction.Commit();
                        var currentChallengeRowId = (int)await connection.ExecuteScalarAsync(commandText, parameters);
                        return currentChallengeRowId;
                    }
                    // TODO add catching Exception as well
                    catch (SqlException ex)
                    {
                        try
                        {
                            transaction.Rollback();
                            throw new Exception($"Exception while trying to insert into CurrentChallengeParticipant table. Transaction successfully rolled back. The exception was: '{ex.Message}'", ex);
                        }
                        catch
                        {
                            throw new Exception($"Exception while trying to rollback transaction. The exception was: '{ex.Message}'", ex);
                        }
                    }
                }
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<CurrentChallengeParticipant>> GetAllRowsInChallengeAsync()
        {
            try
            {
                string commandText = "SELECT * FROM CurrentChallengeParticipant";
                using (SqlConnection connection = CreateConnection())
                {

                    var challengeRows = await connection.QueryAsync<CurrentChallengeParticipant>(commandText);

                    return challengeRows;
                }
            }
            catch (SqlException ex)
            {

                throw new($"Exception while trying to retrieve all rows from CurrentChallengeParticipant table. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<bool> DeleteWebUserFromChallengeAsync(int webUserId)
        {
            try
            {
                string commandText = "DELETE FROM CurrentChallengeParticipant WHERE FKWebUserId = @FKWebUserId";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        FKWebUserId = webUserId,
                    };

                    return await connection.ExecuteAsync(commandText, parameters) > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to delete a row from CurrentChallengeParticipant table. The exception was: '{ex.Message}'", ex);

            }
        }

        // We do this reset because the CurrentChallenge table is a temporary table and only needs to hold data to populate the leaderboard at the end of the challenge
        public async Task<bool> ClearTempTableBeforeNextChallengeAsync()
        {
            try
            {
                string commandText = "DELETE FROM CurrentChallengeParticipant";
                using (SqlConnection connection = CreateConnection())
                {
                    return await connection.ExecuteAsync(commandText) > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to delete contents of CurrentChallengeParticipant table. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<int> GetRowAmountFromDatabaseAsync()
        {
            string commandText = "SELECT COUNT(PKCurrentChallengeParticipantId) FROM CurrentChallengeParticipant";
            try
            {
                using (SqlConnection connection = CreateConnection())
                {
                    var rowAmount = await connection.ExecuteAsync(commandText);
                    return rowAmount;
                }
            }
            catch (SqlException ex)
            {

                throw new Exception($"Exception while trying to count the rows in the CurrentChallengeParticipant table. The exception was: '{ex.Message}'", ex);
            }
        }
    }
}
