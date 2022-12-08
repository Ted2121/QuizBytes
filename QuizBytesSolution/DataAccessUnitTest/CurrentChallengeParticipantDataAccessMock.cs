using Dapper;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System.Data;
using System.Data.SqlClient;

namespace SQLAccessImplementationLibraryUnitTest
{
    public class CurrentChallengeParticipantDataAccessMock : ICurrentChallengeParticipantDataAccess
    {

        public async Task<int> AddWebUserToChallengeAsync(WebUser webUser, Course course)
        {
            var currentChallengeRowId = 0;
            int userLimitForChallenges = 10;

            using (SqlConnection connection = new SqlConnection(Configuration.CONNECTION_STRING))
            {
                connection.Open();
                IsolationLevel isolationLevel = IsolationLevel.RepeatableRead;
                SqlTransaction transaction = connection.BeginTransaction(isolationLevel);
                string commandText = "INSERT INTO TestCurrentChallengeParticipant (FKWebUserId, FKCourseId) VALUES (@FKWebUserId, @FKCourseId); SELECT CAST(scope_identity() AS int)";

                var parameters = new
                {
                    FKWebUserId = webUser.Id,
                    FKCourseId = course.Id
                };
                try
                {
                    var rowAmount = await GetRowAmountFromDatabaseAsync(connection, transaction);
                    if (rowAmount < userLimitForChallenges)
                    {
                        currentChallengeRowId = await connection.QuerySingleAsync<int>(commandText, parameters, transaction: transaction);

                        transaction.Commit();
                        connection.Close();
                    }
                    else
                    {
                        try
                        {
                            transaction.Rollback();
                            throw new Exception($"SqlException while trying to insert into TestCurrentChallengeParticipant table. Transaction successfully rolled back");
                            
                        }
                        catch
                        {
                            throw new Exception($"Exception while trying to rollback transaction.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }


                    return currentChallengeRowId;
                }
                catch (SqlException ex)
                {
                    try
                    {
                        transaction.Rollback();
                        throw new Exception($"SqlException while trying to insert into TestCurrentChallengeParticipant table. Transaction successfully rolled back. The exception was: '{ex.Message}'", ex);
                    }
                    catch
                    {
                        throw new Exception($"Exception while trying to rollback transaction. The exception was: '{ex.Message}'", ex);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Exception while trying to insert into TestCurrentChallengeParticipant table.The exception was: '{e.Message}'", e);
                }

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

        public async Task<bool> DeleteWebUserFromChallengeAsync(int id)
        {
            try
            {
                string commandText = "DELETE FROM TestCurrentChallengeParticipant WHERE FKWebUserId = @FKWebUserId";
                using (SqlConnection connection = new SqlConnection(Configuration.CONNECTION_STRING))
                {
                    var parameters = new
                    {
                        FKWebUserId = id
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
                string commandToReseedIdentity = "DBCC CHECKIDENT ('[TestCurrentChallengeParticipant]', RESEED, 0)";
                using (SqlConnection connection = new SqlConnection(Configuration.CONNECTION_STRING))
                {
                    await connection.ExecuteAsync(commandToReseedIdentity);
                    await connection.ExecuteAsync(commandText);
                    return await GetRowAmountFromDatabaseAsync(connection) == 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to delete contents of TestCurrentChallengeParticipant table. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<int> GetRowAmountFromDatabaseAsync(SqlConnection connection = null, SqlTransaction transaction = null)
        {
            string commandText = "SELECT COUNT(Id) FROM TestCurrentChallengeParticipant";
            try
            {
                if(connection != null)
                {
            var initialConnectionState = connection.State;
                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = commandText;
                        command.Transaction = transaction;
                        if (initialConnectionState == ConnectionState.Closed)
                        { connection.Open(); }
                        var rowAmount = await command.ExecuteScalarAsync();
                        if (initialConnectionState == ConnectionState.Closed)
                        { connection.Close(); }
                        return (int)rowAmount;
                    
                }
                else
                {
                    using (var newConnection = new SqlConnection(Configuration.CONNECTION_STRING))
                    {
                        var rowAmount = await newConnection.ExecuteScalarAsync(commandText);
                        return (int)rowAmount;
                    }
                }


                //using (connection ?? new SqlConnection(Configuration.CONNECTION_STRING))
                //{
                //    SqlCommand command = connection.CreateCommand();
                //    command.CommandText = commandText;

                //    command.Transaction = transaction;
                //    var rowAmount = await command.ExecuteScalarAsync();
                //    return (int)rowAmount;
                    

                //}



            }
            catch (SqlException ex)
            {

                throw new Exception($"Exception while trying to count the rows in the TestCurrentChallengeParticipant table. The exception was: '{ex.Message}'", ex);
            }
        }

        public async Task<bool> CheckIfWebUserIsInChallengeAsync(int webUserId)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.CONNECTION_STRING))
            {
                string readCommand = "SELECT COUNT(FKWebUserId) FROM TestCurrentChallengeParticipant WHERE FKWebUSerId = @FkWebUserId";
                var param = new
                {
                    FKWebUSerId = webUserId
                };
                var result = await connection.QuerySingleAsync<int>(readCommand, param);

                return result > 0;
            }

        }
    }
}
