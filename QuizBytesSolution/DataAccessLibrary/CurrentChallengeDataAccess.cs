using Dapper;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SQLAccessImplementationLibrary
{
    public class CurrentChallengeDataAccess : BaseDataAccess, ICurrentChallengeDataAccess
    {
        public CurrentChallengeDataAccess(string connectionstring) : base(connectionstring)
        {

        }

        public async Task<int> AddWebUserToChallengeAsync(WebUser webUser, Course course)
        {
            string commandText = "INSERT INTO CurrentChallenge (FKWebUserId, FKCourseId) VALUES (@FKWebUserId, @FKCourseId); SELECT CAST(scope_identity() AS int)";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    FKWebUserId = webUser.PKWebUserId,
                    FKCourseId = course.PKCourseId
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                    var currentChallengeRowId = (int)await connection.ExecuteScalarAsync(commandText, parameters);
                    return currentChallengeRowId;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to insert into CurrentChallenge table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<CurrentChallenge>> GetAllRowsInChallengeAsync()
        {
            string commandText = "SELECT * FROM CurrentChallenge";
            using (SqlConnection connection = CreateConnection())
            {

                try
                {
                    var challengeRows = await connection.QueryAsync<CurrentChallenge>(commandText);

                    return challengeRows;
                }
                catch (Exception ex)
                {

                    throw new($"Exception while trying to retrieve all rows from CurrentChallenge table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task DeleteWebUserFromChallengeAsync(WebUser webuser)
        {
            string commandText = "DELETE FROM CurrentChallenge WHERE FKWebUserId = @FkWebUserId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    FKWebUserId = webuser.PKWebUserId
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to delete a row from CurrentChallenge table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        // We do this reset because the CurrentChallenge table is a temporary table and only needs to hold data to populate the leaderboard at the end of the challenge
        public async Task ClearTempTableBeforeNextChallengeAsync()
        {
            string commandText = "DELETE FROM CurrentChallenge";
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    await connection.ExecuteAsync(commandText);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to delete contents of CurrentChallenge table. The exception was: '{ex.Message}'", ex);
                }
            }
        }
    }
}
