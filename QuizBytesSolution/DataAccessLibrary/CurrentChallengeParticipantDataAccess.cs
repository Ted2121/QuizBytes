using Dapper;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System.Data;
using System.Data.SqlClient;

namespace SQLAccessImplementationLibrary;

public class CurrentChallengeParticipantDataAccess : BaseDataAccess, ICurrentChallengeParticipantDataAccess
{

    public CurrentChallengeParticipantDataAccess(string connectionstring) : base(connectionstring)
    {

    }

    public async Task<int> AddWebUserToChallengeAsync(WebUser webUser, Course course)
    {
        var currentChallengeRowId = 0;
        int userLimitForChallenges = 100;

        using (SqlConnection connection = CreateConnection())
        {
            connection.Open();
            IsolationLevel isolationLevel = IsolationLevel.RepeatableRead;
            SqlTransaction transaction = connection.BeginTransaction(isolationLevel);
            string commandText = "INSERT INTO CurrentChallengeParticipant (FKWebUserId, FKCourseId) VALUES (@FKWebUserId, @FKCourseId); SELECT CAST(scope_identity() AS int)";
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
                        return 0;

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
                    return 0;
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
            string commandText = "SELECT * FROM CurrentChallengeParticipant";
            using (SqlConnection connection = CreateConnection())
            {

                var challengeRows = await connection.QueryAsync<CurrentChallengeParticipant>(commandText);

                return challengeRows;
            }
        }
        catch (Exception ex)
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
        catch (Exception ex)
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
            string commandToReseedIdentity = "DBCC CHECKIDENT ('[CurrentChallengeParticipant]', RESEED, 0)";

            using (SqlConnection connection = CreateConnection())
            {
                await connection.ExecuteAsync(commandToReseedIdentity);
                await connection.ExecuteAsync(commandText);
                return await GetRowAmountFromDatabaseAsync(connection) == 0;
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Exception while trying to delete contents of CurrentChallengeParticipant table. The exception was: '{ex.Message}'", ex);

        }
    }

    public async Task<int> GetRowAmountFromDatabaseAsync(SqlConnection connection = null, SqlTransaction transaction = null)
    {
        string commandText = "SELECT COUNT(Id) FROM CurrentChallengeParticipant";
        try
        {
            if (connection != null)
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
                using (var newConnection = CreateConnection())
                {
                    var rowAmount = await newConnection.ExecuteScalarAsync(commandText);
                    return (int)rowAmount;
                }
            }
        }
        catch (Exception ex)
        {

            throw new Exception($"Exception while trying to count the rows in the CurrentChallengeParticipant table. The exception was: '{ex.Message}'", ex);
        }
    }

    public async Task<bool> CheckIfWebUserIsInChallengeAsync(int webUserId)
    {
        try
        {
            using (SqlConnection connection = CreateConnection())
            {
                string readCommand = "SELECT COUNT(FKWebUserId) FROM CurrentChallengeParticipant WHERE FKWebUSerId = @FkWebUserId";
                var param = new
                {
                    FKWebUSerId = webUserId
                };
                var result = await connection.QuerySingleAsync<int>(readCommand, param);

                return result > 0;
            }

        }
        catch (Exception ex)
        {
            throw new Exception($"Exception while trying to check if user is in the CurrentChallengeParticipant table. The exception was: '{ex.Message}'", ex);
        }
    }

}

