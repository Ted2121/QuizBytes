﻿using Dapper;
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
                string commandText = "DELETE FROM WebUser WHERE Id = @Id";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        Id = webUserId
                    };


                   return await connection.ExecuteAsync(commandText, parameters)>0;

                }
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                throw new($"Exception while trying to find the WebUser with the '{username}'. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<WebUser> GetWebUserByIdAsync(int webUserId)
        {
            try
            {
                string commandText = "SELECT * FROM WebUser WHERE Id = @Id";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        Id = webUserId
                    };

                    var webUser = await connection.QuerySingleOrDefaultAsync<WebUser>(commandText, parameters);

                    return webUser;
                }
            }
            catch (Exception ex)
            {
                throw new($"Exception while trying to find the WebUser with the '{webUserId}'. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<int> InsertWebUserAsync(WebUser webUser)
        {
            try
            {
                string commandText = "INSERT INTO WebUser(Username, PasswordHash, TotalPoints, AvailablePoints, Email, ElapsedSecondsInChallenge, CorrectAnswers) VALUES (@Username, @PasswordHash, @TotalPoints, @AvailablePoints, @Email, @ElapsedSecondsInChallenge, @CorrectAnswers); SELECT CAST(scope_identity() AS int)";

                using (SqlConnection connection = CreateConnection())
                {

                    var parameters = new
                    {
                        Username = webUser.Username,
                        PasswordHash = BCryptTool.HashPassword(webUser.PasswordHash),
                        TotalPoints = webUser.TotalPoints,
                        AvailablePoints = webUser.AvailablePoints,
                        Email = webUser.Email,
                        ElapsedSecondsInChallenge = webUser.ElapsedSecondsInChallenge,
                        CorrectAnswers = webUser.CorrectAnswers
                    };

                    return webUser.Id = await connection.QuerySingleAsync<int>(commandText, parameters);
                }
            }
            catch (Exception ex)
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
                    "ElapsedSecondsInChallenge = @ElapsedSecondsInChallenge, " +
                    "CorrectAnswers = @CorrectAnswers " +
                    "WHERE Id = @Id;";

                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        Username = webUser.Username,
                        TotalPoints = webUser.TotalPoints,
                        AvailablePoints = webUser.AvailablePoints,
                        Email = webUser.Email,
                        ElapsedSecondsInChallenge = webUser.ElapsedSecondsInChallenge,
                        CorrectAnswers = webUser.CorrectAnswers,
                        Id = webUser.Id
                    };

                    return await connection.ExecuteAsync(commandText, parameters)>0;

                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception while trying to update WebUser. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<WebUser> LoginAsync(string username, string password)
        {
            try
            {
                string commandText = "SELECT Id, PasswordHash FROM WebUser WHERE Username = @Username";

                using var connection = CreateConnection();

                var webUserTuple = await connection.QueryFirstOrDefaultAsync<WebUserTuple>(commandText, new {UserName = username});

                if(webUserTuple != null && BCryptTool.ValidatePassword(password, webUserTuple.PasswordHash))
                {
                    return await GetWebUserByIdAsync(webUserTuple.Id);
                }
                else
                {
                    throw new Exception($"Error logging in for WebUser with username: {username}");
                }
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
                string commandText = "UPDATE WebUser SET PasswordHash = @PasswordHash WHERE Id = @Id;";
                var user = await LoginAsync(username, oldPassword);
                var id = user.Id;
                if(id > 0)
                {
                    var newPasswordHash = BCryptTool.HashPassword(newPassword);
                    using var connection = CreateConnection();
                    return await connection.ExecuteAsync(commandText, new { Id = id, PasswordHash = newPasswordHash }) > 0;
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
            public int Id;
            public string PasswordHash;
        }
    }
}
