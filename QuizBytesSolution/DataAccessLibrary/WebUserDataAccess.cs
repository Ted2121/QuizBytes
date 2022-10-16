using Dapper;
using DataAccessDefinitionLibrary;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.DAO_models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAccessImplementationLibrary
{
public class WebUserDataAccess : IWebUserDataAccess
{


    public async Task DeleteWebUserAsync(WebUser webUser)
    {
        string commandText = "DELETE FROM WebUsers WHERE WebUserUserName = @WebUserUserName";
        using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
        {
            var parameters = new
            {
                WebUserUserName = webUser.Username
            };

            try
            {
                await connection.ExecuteAsync(commandText, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception while trying to delete a row from WebUsers table. The exception was: '{ex.Message}'", ex);
            }
        }
    }

    public async Task<IEnumerable<WebUser>> GetAllWebUsersAsync()
    {
        string commandText = "SELECT * FROM WebUsers";
        using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
        {
            try
            {
                var webUsers = await connection.QueryAsync<WebUser>(commandText);

                return webUsers;
            }
            catch(Exception ex)
            {
                throw new Exception($"Exception while trying to read all rows from the WebUsers table. The exception was: '{ex.Message}'", ex);
            }
        }
    }

    public async Task<WebUser> GetWebUserByUsernameAsync(string username)
    {
        string commandText = "SELECT * FROM WebUsers WHERE WebUserUserName = @WebUserUserName";
        using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
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
            catch(Exception ex)
            {
                throw new($"Exception while trying to find the WebUser with the '{username}'. The exception was: '{ex.Message}'", ex);
            }
        }
    }

    public async Task<WebUser> InsertWebUserAsync(WebUser webUser)
    {
        string commandText = "INSERT INTO WebUsers(WebUserUserName, PasswordHash, TotalPoints, AvailablePoints, Email) VALUES (@WebUserUserName, @PasswordHash, @TotalPoints, @AvailablePoints, @Email)";
        using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
        {

            var insertParameters = new
            {
                WebUserUserName = webUser.Username,
                WebUserPasswordHash = webUser.Password,
                TotalPoints = webUser.TotalPoints,
                AvailablePoints = webUser.AvailablePoints,
                Email = webUser.Email
            };

            try
            {
                await connection.ExecuteAsync(commandText, insertParameters);
                return webUser;
            }
            catch (Exception ex)
            {

                throw new($"Exception while trying to insert a WebUser object. The exception was: '{ex.Message}'", ex);
            }
        }
    }

    public async Task UpdateWebUserAsync(WebUser webUser) //add parameter string username??
    {
        string commandText = "UPDATE WebUser" +
            "SET WebUserUserName = @WebUserUserName," +
            "PasswordHash = @PasswordHash," +
            "TotalPoints = @TotalPoints" +
            "AvailablePoints = @AvailavlePoints" +
            "Email = @Email" +
            "WHERE WebUserUserName = @WebUserUserName"; //rename @WebUserUserName to NewWebUserUserName?
        using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
        {
            var parameters = new
            {
                WebUserUserName = webUser.Username,
                WebUserPasswordHash = webUser.Password,
                TotalPoints = webUser.TotalPoints,
                AvailablePoints = webUser.AvailablePoints,
                Email = webUser.Email
                //NewWebUserUserName = username;
                // I believe that this is an issue : We are updating the primary key which is
                // affecting another table that is using said primary key as a foreign key, meaning that we should add WebUserID to the database
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
