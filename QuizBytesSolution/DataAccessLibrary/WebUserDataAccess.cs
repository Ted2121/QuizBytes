using Dapper;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System.Data.SqlClient;

namespace SQLAccessImplementationLibrary
{
    public class WebUserDataAccess : BaseDataAccess, IWebUserDataAccess
    {
        public WebUserDataAccess(string connectionstring) : base(connectionstring)
        {
        }

        public async Task DeleteWebUserAsync(WebUser webUser)
        {
            string commandText = "DELETE FROM WebUser WHERE PKWebUserId = @PKWebUserId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    PKWebUserId = webUser.PKWebUserId
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to delete a row from WebUser table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<WebUser>> GetAllWebUsersAsync()
        {
            string commandText = "SELECT * FROM WebUser";
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    var webUsers = await connection.QueryAsync<WebUser>(commandText);

                    return webUsers;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the WebUser table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<WebUser> GetWebUserByUsernameAsync(string username)
        {
            string commandText = "SELECT * FROM WebUser WHERE Username = @Username";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    Username = username
                };

                try
                {
                    var webUser = await connection.QuerySingleOrDefaultAsync<WebUser>(commandText, parameters);

                    return webUser;
                }
                catch (Exception ex)
                {
                    throw new($"Exception while trying to find the WebUser with the '{username}'. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<WebUser> GetWebUserByIdAsync(int webUserId)
        {
            string commandText = "SELECT * FROM WebUser WHERE PKWebUserId = @PKWebUserId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    PKWebUserId = webUserId
                };

                try
                {
                    var webUser = await connection.QuerySingleOrDefaultAsync<WebUser>(commandText, parameters);

                    return webUser;
                }
                catch (Exception ex)
                {
                    throw new($"Exception while trying to find the WebUser with the '{webUserId}'. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<WebUser> InsertWebUserAsync(WebUser webUser)
        {
            string commandText = "INSERT INTO WebUsers(Username, PasswordHash, TotalPoints, AvailablePoints, Email, PointsAccumulatedInChallenge, ElapsedSecondsInChallenge) VALUES (@Username, @PasswordHash, @TotalPoints, @AvailablePoints, @Email, @PointsAccumulatedInChallenge, @ElapsedSecondsInChallenge); SELECT CAST(scope_identity() AS int)";

            using (SqlConnection connection = CreateConnection())
            {

                var parameters = new
                {
                    Username = webUser.Username,
                    PasswordHash = webUser.PasswordHash,
                    TotalPoints = webUser.TotalPoints,
                    AvailablePoints = webUser.AvailablePoints,
                    Email = webUser.Email,
                    PointsAccumulatedInChallenge = webUser.PointsAccumulatedInChallenge,
                    ElapsedSecondsInChallenge = webUser.ElapsedSecondsInChallenge
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                    webUser.PKWebUserId = (int)await connection.ExecuteScalarAsync(commandText, parameters);
                    return webUser;
                }
                catch (Exception ex)
                {

                    throw new($"Exception while trying to insert a WebUser object. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task UpdateWebUserAsync(WebUser webUser)
        {
            string commandText = "UPDATE WebUser " +
                "SET PasswordHash = @PasswordHash, " +
                "TotalPoints = @TotalPoints, " +
                "AvailablePoints = @AvailablePoints, " +
                "Email = @Email, " +
                "PointsAccumulatedInChallenge = @PointsAccumulatedInChallenge, " +
                "ElapsedSecondsInChallenge = @ElapsedSecondsInChallenge " +
                "WHERE PKWebUserId = @PKWebUserId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    WebUserId = webUser.PKWebUserId,
                    PasswordHash = webUser.PasswordHash,
                    TotalPoints = webUser.TotalPoints,
                    AvailablePoints = webUser.AvailablePoints,
                    Email = webUser.Email,
                    PointsAccumulatedInChallenge = webUser.PointsAccumulatedInChallenge,
                    ElapsedSecondsInChallenge = webUser.ElapsedSecondsInChallenge,
                    PKWebUserId = webUser.PKWebUserId
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);

                }
                catch (Exception ex)
                {

                    throw new Exception($"Exception while trying to update WebUser. The exception was: '{ex.Message}'", ex);
                }
            }
        }
    }
}
