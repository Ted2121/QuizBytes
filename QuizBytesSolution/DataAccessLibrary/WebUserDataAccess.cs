using Dapper;
using DataAccessDefinitionLibrary.Authentication;
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

        public async Task<bool> DeleteWebUserAsync(int webUserId)
        {
            try
            {
                string commandText = "DELETE FROM WebUser WHERE PKWebUserId = @PKWebUserId";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        PKWebUserId = webUserId
                    };


                   return await connection.ExecuteAsync(commandText, parameters)>0;

                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to delete a row from WebUser table. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<IEnumerable<WebUser>> GetAllWebUsersAsync()
        {
            try
            {
                string commandText = "SELECT * FROM WebUser";
                using (SqlConnection connection = CreateConnection())
                {
                    var webUsers = await connection.QueryAsync<WebUser>(commandText);

                    return webUsers;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to read all rows from the WebUser table. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<WebUser> GetWebUserByUsernameAsync(string username)
        {
            try
            {
                string commandText = "SELECT * FROM WebUser WHERE Username = @Username";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        Username = username
                    };

                    var webUser = await connection.QuerySingleOrDefaultAsync<WebUser>(commandText, parameters);

                    return webUser;
                }
            }
            catch (SqlException ex)
            {
                throw new($"Exception while trying to find the WebUser with the '{username}'. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<WebUser> GetWebUserByIdAsync(int webUserId)
        {
            try
            {
                string commandText = "SELECT * FROM WebUser WHERE PKWebUserId = @PKWebUserId";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        PKWebUserId = webUserId
                    };

                    var webUser = await connection.QuerySingleOrDefaultAsync<WebUser>(commandText, parameters);

                    return webUser;
                }
            }
            catch (SqlException ex)
            {
                throw new($"Exception while trying to find the WebUser with the '{webUserId}'. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<int> InsertWebUserAsync(WebUser webUser)
        {
            try
            {
                string commandText = "INSERT INTO WebUser(Username, PasswordHash, TotalPoints, AvailablePoints, Email, PointsAccumulatedInChallenge, ElapsedSecondsInChallenge) VALUES (@Username, @PasswordHash, @TotalPoints, @AvailablePoints, @Email, @PointsAccumulatedInChallenge, @ElapsedSecondsInChallenge); SELECT CAST(scope_identity() AS int)";

                using (SqlConnection connection = CreateConnection())
                {

                    var parameters = new
                    {
                        Username = webUser.Username,
                        PasswordHash = BCryptTool.HashPassword(webUser.PasswordHash),
                        TotalPoints = webUser.TotalPoints,
                        AvailablePoints = webUser.AvailablePoints,
                        Email = webUser.Email,
                        PointsAccumulatedInChallenge = webUser.PointsAccumulatedInChallenge,
                        ElapsedSecondsInChallenge = webUser.ElapsedSecondsInChallenge
                    };

                    return webUser.PKWebUserId = await connection.QuerySingleAsync<int>(commandText, parameters);
                }
            }
            catch (SqlException ex)
            {

                throw new($"Exception while trying to insert a WebUser object. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<bool> UpdateWebUserAsync(WebUser webUser)
        {
            try
            {
                string commandText = "UPDATE WebUser " +
                    "SET " +
                    "Username = @Username, " +
                    "TotalPoints = @TotalPoints, " +
                    "AvailablePoints = @AvailablePoints, " +
                    "Email = @Email, " +
                    "PointsAccumulatedInChallenge = @PointsAccumulatedInChallenge, " +
                    "ElapsedSecondsInChallenge = @ElapsedSecondsInChallenge " +
                    "WHERE PKWebUserId = @PKWebUserId;";

                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        Username = webUser.Username,
                        TotalPoints = webUser.TotalPoints,
                        AvailablePoints = webUser.AvailablePoints,
                        Email = webUser.Email,
                        PointsAccumulatedInChallenge = webUser.PointsAccumulatedInChallenge,
                        ElapsedSecondsInChallenge = webUser.ElapsedSecondsInChallenge,
                        PKWebUserId = webUser.PKWebUserId
                    };

                    return await connection.ExecuteAsync(commandText, parameters)>0;

                }
            }
            catch (SqlException ex)
            {

                throw new Exception($"Exception while trying to update WebUser. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<int> LoginAsync(string username, string password)
        {
            try
            {
                string commandText = "SELECT PKWebUserId, PasswordHash FROM WebUser WHERE Username = @Username";

                using var connection = CreateConnection();

                var webUserTuple = await connection.QueryFirstOrDefaultAsync<WebUserTuple>(commandText, new {UserName = username});

                if(webUserTuple != null && BCryptTool.ValidatePassword(password, webUserTuple.PasswordHash))
                {
                    return webUserTuple.PKWebUserId;
                }
                return -1;
            }
            catch (Exception ex)
            {

                throw new Exception($"Error logging in for WebUser with username: {username}: '{ex.Message}'.", ex);
            }
        }

        public async Task<bool> UpdatePasswordAsync(string username, string oldPassword, string newPassword)
        {
            try
            {
                string commandText = "UPDATE WebUser SET PasswordHash = @PasswordHash WHERE PKWebUserId = @PKWebUserId;";
                var id = await LoginAsync(username, oldPassword);
                if(id > 0)
                {
                    var newPasswordHash = BCryptTool.HashPassword(newPassword);
                    using var connection = CreateConnection();
                    return await connection.ExecuteAsync(commandText, new { PKWebUserId = id, NewPasswordHash = newPasswordHash }) > 0;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception($"Error updating password: '{ex.Message}'.", ex);
            }
        }

        internal class WebUserTuple
        {
            public int PKWebUserId;
            public string PasswordHash;
        }
    }
}
