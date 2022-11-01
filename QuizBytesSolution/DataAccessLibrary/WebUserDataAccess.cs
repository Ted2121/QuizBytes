using Dapper;
using DataAccessDefinitionLibrary;
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
public class WebUserDataAccess : BaseDataAccess, IWebUserDataAccess
{
    public WebUserDataAccess(string connectionstring) : base(connectionstring)
    {
    }

    public async Task DeleteWebUserAsync(WebUser webUser)
{
    string commandText = "DELETE FROM WebUsers WHERE WebUserId = @UWebUserId";
    using (SqlConnection connection = CreateConnection())
    {
        var parameters = new
        {
            WebUserId = webUser.Id
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
    using (SqlConnection connection = CreateConnection())
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
    string commandText = "SELECT * FROM WebUsers WHERE Username = @Username";
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
        catch(Exception ex)
        {
            throw new($"Exception while trying to find the WebUser with the '{username}'. The exception was: '{ex.Message}'", ex);
        }
    }
}

    public async Task<WebUser> GetWebUserByIdAsync(int id)
    {
        string commandText = "SELECT * FROM WebUsers WHERE WebUserId = @WebUserId";
        using (SqlConnection connection = CreateConnection())
        {
            var parameters = new
            {
                WebUserId = id
            };

            try
            {
                var webUser = await connection.QuerySingleOrDefaultAsync<WebUser>(commandText, parameters);

                return webUser;
            }
            catch (Exception ex)
            {
                throw new($"Exception while trying to find the WebUser with the '{id}'. The exception was: '{ex.Message}'", ex);
            }
        }
    }

    public async Task<WebUser> InsertWebUserAsync(WebUser webUser)
{
    string commandText = "INSERT INTO WebUsers(Username, PasswordHash, TotalPoints, AvailablePoints, Email) VALUES (@Username, @PasswordHash, @TotalPoints, @AvailablePoints, @Email)";
    using (SqlConnection connection = CreateConnection())
    {

        var insertParameters = new
        {
            Username = webUser.Username,
            PasswordHash = webUser.Password,
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

public async Task UpdateWebUserAsync(WebUser webUser)
{
    string commandText = "UPDATE WebUser" +
        "SET PasswordHash = @PasswordHash," +
        "TotalPoints = @TotalPoints" +
        "AvailablePoints = @AvailablePoints" +
        "Email = @Email" +
        "WHERE WebUserId = @WebUserId";
    using (SqlConnection connection = CreateConnection())
    {
        var parameters = new
        {
            WebUserId = webUser.Id,
            PasswordHash = webUser.Password,
            TotalPoints = webUser.TotalPoints,
            AvailablePoints = webUser.AvailablePoints,
            Email = webUser.Email
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
