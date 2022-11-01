using Dapper;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAccessImplementationLibrary
{
    public class CurrentChallengeDataAccess : BaseDataAccess, ICurrentChallengeDataAccess
    {
        public CurrentChallengeDataAccess(string connectionstring) : base(connectionstring)
        {

        }

        public async Task AddWebUserToChallengeAsync(WebUser webuser, Course course)
        {
            string commandText = "INSERT INTO CurrentChallenge (FKWebUserId, FKCourseId) VALUES (@FKWebUserId, @FKCourseId); SELECT CAST(scope_identity() AS int)";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    FKWebUserId = webuser.Id,
                    FKCourseId = course.Id
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to insert into CurrentChallenge table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<WebUser>> GetAllUsersInChallengeAsync()
        {
            string commandText = "SELECT FKWebUserId FROM CurrentChallenge";
            using (SqlConnection connection = CreateConnection())
            {

                try
                {
                    var webusers = await connection.QueryAsync<WebUser>(commandText);

                    return webusers;
                }
                catch (Exception ex)
                {

                    throw new($"Exception while trying to retrieve all users from CurrentChallenge table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<WebUser>> GetChallengeTopThreeScorersAsync()
        {

        }

        public async Task RemoveWebUserFromChallengeAsync(WebUser webuser)
        {
            string commandText = "DELETE FROM CurrentChallenge WHERE FKWebUserId = @FkWebUserId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    FKWebUserId = webuser.Id
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
        public async Task DeleteTempTableAfterChallengeIsDoneAsync()
        {
            string commandText = "DELETE Table CurrentChallenge";
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
