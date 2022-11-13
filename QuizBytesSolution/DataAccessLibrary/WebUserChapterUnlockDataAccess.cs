﻿using Dapper;
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

        public async Task<bool> DeleteWebUserChapterUnlockAsync(WebUserChapterUnlock webUserChapterUnlock)
        {
            try
            {
                string commandText = "DELETE FROM WebUserChapterUnlock WHERE FKWebUserId = @FKWebUserId AND FKChapterId = @FKChapterId";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        FKWebUserId = webUserChapterUnlock.FKWebUserId,
                        FKChapterId = webUserChapterUnlock.FKChapterId

                    };

                    return await connection.ExecuteAsync(commandText, parameters) > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to delete a row from WebUserChapterUnlock table. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<IEnumerable<WebUserChapterUnlock>> GetAllWebUserChapterUnlocksAsync()
        {
            try
            {
                string commandText = " SELECT * FROM WebUserChapterUnlock";
                using (SqlConnection connection = CreateConnection())
                {
                    var webUserChapterUnlocks = await connection.QueryAsync<WebUserChapterUnlock>(commandText);

                    return webUserChapterUnlocks;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to read all rows from the WebUserChapterUnlock table. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<IEnumerable<WebUserChapterUnlock>> GetAllWebUserChapterUnlocksByChapterAsync(Chapter chapter)
        {
            try
            {
                string commandText = "SELECT * FROM WebUserChapterUnlock WHERE FKChapterId = @FKChapterId";
                using (SqlConnection connection = CreateConnection())
                {

                    var parameters = new
                    {
                        FKChapterId = chapter.PKChapterId
                    };

                    var webUserChapterUnlocks = await connection.QueryAsync<WebUserChapterUnlock>(commandText, parameters);

                    return webUserChapterUnlocks;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to read all rows from the WebUserChapterUnlock table with the foreign key attribute: FKChapterId = {chapter.PKChapterId}. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<IEnumerable<WebUserChapterUnlock>> GetAllWebUserChapterUnlocksByWebUserAsync(WebUser webUser)
        {
            try
            {
                string commandText = "SELECT * FROM WebUserChapterUnlock WHERE FKWebUserId = @FKChapterId";
                using (SqlConnection connection = CreateConnection())
                {

                    var parameters = new
                    {
                        FKWebUserId = webUser.PKWebUserId
                    };

                    var webUserChapterUnlocks = await connection.QueryAsync<WebUserChapterUnlock>(commandText, parameters);

                    return webUserChapterUnlocks;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to read all rows from the WebUserChapterUnlock table with the foreign key attribute: FKChapterId = {webUser.PKWebUserId}. The exception was: '{ex.Message}'", ex);

            }
        }


        public async Task InsertWebUserChapterUnlockAsync(WebUserChapterUnlock webUserChapterUnlock)
        {
            try
            {
                string commandText = "INSERT INTO WebUserChapterUnlock (FKChapterId, FKWebUserId) VALUES (@FKChapterId, @FKWebUserId))";

                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        FKChapterId = webUserChapterUnlock.FKChapterId,
                        FKWebUserId = webUserChapterUnlock.FKWebUserId
                    };

                    await connection.ExecuteAsync(commandText, parameters);
                }
            }
            catch (SqlException ex)
            {
                throw new($"Exception while trying to insert a WebUserChapterUnlock object. The exception was: '{ex.Message}'", ex);

            }
        }


    }
}

