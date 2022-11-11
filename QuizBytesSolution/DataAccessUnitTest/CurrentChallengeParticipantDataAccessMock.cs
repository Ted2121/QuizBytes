using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using SQLAccessImplementationLibrary;

namespace SQLAccessImplementationLibraryUnitTest
{
    public class CurrentChallengeParticipantDataAccessMock : BaseDataAccess, ICurrentChallengeParticipantDataAccess
    {

        public CurrentChallengeParticipantDataAccessMock(string connectionstring) : base(connectionstring)
        {

        }

        public async Task<int> AddWebUserToChallengeAsync(WebUser webUser, Course course)
        {
            int userLimitForChallenges = 100;
            var rowAmount = await GetRowAmountFromDatabaseAsync();
            if (rowAmount < userLimitForChallenges)
            {
                using (SqlConnection connection = new SqlConnection(Configuration.CONNECTION_STRING))
                {
                    connection.Open();
                    IsolationLevel isolationLevel = IsolationLevel.RepeatableRead;
                    SqlTransaction transaction = connection.BeginTransaction(isolationLevel);
                    string commandText = "INSERT INTO TestCurrentChallengeParticipant (FKWebUserId, FKCourseId) VALUES (@FKWebUserId, @FKCourseId); SELECT CAST(scope_identity() AS int)";
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
                    catch (SqlException ex)
                    {
                        try
                        {
                            transaction.Rollback();
                            throw new Exception($"Exception while trying to insert into TestCurrentChallengeParticipant table. Transaction successfully rolled back. The exception was: '{ex.Message}'", ex);
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
                string commandText = "SELECT * FROM TestCurrentChallengeParticipant";
                using (SqlConnection connection = new SqlConnection(Configuration.CONNECTION_STRING))
                {

                    var challengeRows = await connection.QueryAsync<CurrentChallengeParticipant>(commandText);

                    return challengeRows;
                }
            }
            catch (SqlException ex)
            {

                throw new($"Exception while trying to retrieve all rows from TestCurrentChallengeParticipant table. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<bool> DeleteWebUserFromChallengeAsync(WebUser webuser)
        {
            try
            {
                string commandText = "DELETE FROM TestCurrentChallengeParticipant WHERE FKWebUserId = @FKWebUserId";
                using (SqlConnection connection = new SqlConnection(Configuration.CONNECTION_STRING))
                {
                    var parameters = new
                    {
                        FKWebUserId = webuser.PKWebUserId
                    };

                    return await connection.ExecuteAsync(commandText, parameters) > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to delete a row from TestCurrentChallengeParticipant table. The exception was: '{ex.Message}'", ex);

            }
        }

        // We do this reset because the CurrentChallenge table is a temporary table and only needs to hold data to populate the leaderboard at the end of the challenge
        public async Task<bool> ClearTempTableBeforeNextChallengeAsync()
        {
            try
            {
                string commandText = "DELETE FROM TestCurrentChallengeParticipant";
                using (SqlConnection connection = new SqlConnection(Configuration.CONNECTION_STRING))
                {
                    return await connection.ExecuteAsync(commandText) > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to delete contents of TestCurrentChallengeParticipant table. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<int> GetRowAmountFromDatabaseAsync()
        {
            string commandText = "SELECT COUNT PKCurrentChallengeParticipantId FROM TestCurrentChallengeParticipant";
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.CONNECTION_STRING))
                {
                    var rowAmount = await connection.ExecuteAsync(commandText);
                    return rowAmount;
                }
            }
            catch (SqlException ex)
            {

                throw new Exception($"Exception while trying to count the rows in the TestCurrentChallengeParticipant table. The exception was: '{ex.Message}'", ex);
            }
        }
    }
}
