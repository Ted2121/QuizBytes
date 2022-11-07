using Dapper;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace SQLAccessImplementationLibrary
{
    public class WebUserChapterUnlockDataAccess : BaseDataAccess, IWebUserChapterUnlockDataAccess
    {
        public WebUserChapterUnlockDataAccess(string connectionstring) : base(connectionstring)
        {
        }

        public async Task DeleteWebUserChapterUnlockAsync(WebUserChapterUnlock webUserChapterUnlock)
        {
            string commandText = "DELETE FROM WebUserChapterUnlock WHERE FKWebUserId = @FKWebUserId AND FKChapterId = @FKChapterId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    FKWebUserId = webUserChapterUnlock.FKWebUserId,
                    FKChapterId = webUserChapterUnlock.FKChapterId

                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to delete a row from WebUserChapterUnlock table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<WebUserChapterUnlock>> GetAllWebUserChapterUnlocksAsync()
        {
            string commandText = " SELECT * FROM WebUserChapterUnlock";
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    var webUserChapterUnlocks = await connection.QueryAsync<WebUserChapterUnlock>(commandText);

                    return webUserChapterUnlocks;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the WebUserChapterUnlock table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<WebUserChapterUnlock>> GetAllWebUserChapterUnlocksByChapterAsync(Chapter chapter)
        {
            string commandText = "SELECT * FROM WebUserChapterUnlock WHERE FKChapterId = @FKChapterId";
            using (SqlConnection connection = CreateConnection())
            {

                try
                {
                    var parameters = new
                    {
                        FKChapterId = chapter.PKChapterId
                    };

                    var webUserChapterUnlocks = await connection.QueryAsync<WebUserChapterUnlock>(commandText, parameters);

                    return webUserChapterUnlocks;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the WebUserChapterUnlock table with the foreign key attribute: FKChapterId = {chapter.PKChapterId}. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<WebUserChapterUnlock>> GetAllWebUserChapterUnlocksByWebUserAsync(WebUser webUser)
        {
            string commandText = "SELECT * FROM WebUserChapterUnlock WHERE FKWebUserId = @FKChapterId";
            using (SqlConnection connection = CreateConnection())
            {

                try
                {
                    var parameters = new
                    {
                        FKWebUserId = webUser.PKWebUserId
                    };

                    var webUserChapterUnlocks = await connection.QueryAsync<WebUserChapterUnlock>(commandText, parameters);

                    return webUserChapterUnlocks;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the WebUserChapterUnlock table with the foreign key attribute: FKChapterId = {webUser.PKWebUserId}. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        
        public async Task InsertWebUserChapterUnlockAsync(WebUserChapterUnlock webUserChapterUnlock)
        {
            string commandText = "INSERT INTO WebUserChapterUnlock (FKChapterId, FKWebUserId) VALUES (@FKChapterId, @FKWebUserId))";

            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    FKChapterId = webUserChapterUnlock.FKChapterId,
                    FKWebUserId = webUserChapterUnlock.FKWebUserId
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }
                catch (Exception ex)
                {
                    throw new($"Exception while trying to insert a WebUserChapterUnlock object. The exception was: '{ex.Message}'", ex);
                }
            }
        }


    }
}

