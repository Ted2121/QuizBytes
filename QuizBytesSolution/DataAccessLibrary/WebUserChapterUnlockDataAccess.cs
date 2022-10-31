using Dapper;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System.Data.SqlClient;

namespace SQLAccessImplementationLibrary
{
    public class WebUserChapterUnlockDataAccess : BaseDataAccess, IWebUserChapterUnlockDataAccess
    {
        public WebUserChapterUnlockDataAccess(string connectionstring) : base(connectionstring)
        {
        }

        public async Task DeleteWebUserChapterUnlockAsync(WebUserChapterUnlock webUserChapterUnlock)
        {
            string commandText = "DELETE FROM WebUserChapterUnlocks WHERE FKWebUserId = @FKWebUserId AND FKChapterId = @FKChapterId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    FKWebUserId = webUserChapterUnlock.WebUserId,
                    FKChapterId = webUserChapterUnlock.ChapterId

                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to delete a row from WebUserChapterUnlocks table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<WebUserChapterUnlock>> GetAllWebUserChapterUnlocksAsync()
        {
            string commandText = " SELECT * FROM WebUserChapterUnlocks";
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    var webUserChapterUnlocks = await connection.QueryAsync<WebUserChapterUnlock>(commandText);

                    return webUserChapterUnlocks;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the WebUserChapterUnlocks table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<WebUserChapterUnlock>> GetAllWebUserChapterUnlocksByChapterAsync(Chapter chapter)
        {
            string commandText = "SELECT * FROM WebUserChapterUnlocks WHERE FKChapterId = @FKChapterId";
            using (SqlConnection connection = CreateConnection())
            {

                try
                {
                    var parameters = new
                    {
                        FKChapterId = chapter.Id
                    };

                    var webUserChapterUnlocks = await connection.QueryAsync<WebUserChapterUnlock>(commandText, parameters);

                    return webUserChapterUnlocks;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the WebUserChapterUnlocks table with the foreign key attribute: FKChapterId = {chapter.Id}. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<WebUserChapterUnlock>> GetAllWebUserChapterUnlocksByWebUserAsync(WebUser webUser)
        {
            string commandText = "SELECT * FROM WebUserChapterUnlocks WHERE FKWebUserId = @FKChapterId";
            using (SqlConnection connection = CreateConnection())
            {

                try
                {
                    var parameters = new
                    {
                        FKWebUserId = webUser.Id
                    };

                    var webUserChapterUnlocks = await connection.QueryAsync<WebUserChapterUnlock>(commandText, parameters);

                    return webUserChapterUnlocks;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the WebUserChapterUnlocks table with the foreign key attribute: FKChapterId = {webUser.Id}. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task InsertWebUserChapterUnlockAsync(WebUserChapterUnlock webUserChapterUnlock)
        {
            string commandText = "INSERT INTO WebUserChapterUnlockId (FKChapterId, FKWebUserId) VALUES (@FKChapterId, @FKWebUserId))";

            using (SqlConnection connection = CreateConnection())
            {
                var insertParameters = new
                {
                    FKChapterId = webUserChapterUnlock.ChapterId,
                    FKWebUserId = webUserChapterUnlock.WebUserId
                };

                try
                {
                    await connection.ExecuteAsync(commandText, insertParameters);
                }
                catch (Exception ex)
                {
                    throw new($"Exception while trying to insert a WebUserChapterUnlock object. The exception was: '{ex.Message}'", ex);
                }
            }
        }


    }
}

