using Dapper;
using DataAccessDefinitionLibrary;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.DAO_models;
using System.Data.SqlClient;

namespace SQLAccessImplementationLibrary
{
    public class ChapterDataAccess : IChapterDataAccess
    {


        public async Task DeleteChapterAsync(Chapter chapter)
        {
            string commandText = "DELETE FROM Chapters WHERE ChapterId = @ChapterId";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                var parameters = new
                {
                    ChapterId = chapter.Id
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to delete a row from Chapters table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<Chapter>> GetAllChaptersAsync()
        {
            string commandText = "SELECT* FROM Chapters";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                try
                {
                    var chapters = await connection.QueryAsync<Chapter>(commandText);

                    return chapters;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Chapters table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<Chapter>> GetAllChaptersBySubjectAsync(Subject subject)
        {
            string commandText = "SELECT * FROM Chapters WHERE FKSubjectId = @FKSubjectId";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {

                try
                {
                    var parameters = new
                    {
                        FKSubjectId = subject.Id
                    };

                    var chapters = await connection.QueryAsync<Chapter>(commandText, parameters);

                    return chapters;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Chapters table with the foreign key attribute: FKSubjectId = {subject.Id}. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<Chapter> GetChapterByIdAsync(int chapterId)
        {
            string commandText = "SELECT * FROM Chapters WHERE ChapterId = @ChapterId";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                var parameters = new
                {
                    ChapterId = chapterId
                };

                try
                {
                    var chapter = await connection.QuerySingleOrDefaultAsync<Chapter>(commandText, parameters);

                    return chapter;
                }
                catch (Exception ex)
                {

                    throw new ($"Exception while trying to find the Chapter with the '{chapterId}'. The exception was: '{ex.Message}'", ex);
                }

            }
        }

        public async Task<Chapter> GetChapterByNameAsync(string chapterName)
        {
            string commandText = "SELECT * FROM Chapters WHERE ChapterName = @ChapterName";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                var parameters = new
                {
                    ChapterName = chapterName
                };

                try
                {
                    var chapter = await connection.QuerySingleOrDefaultAsync<Chapter>(commandText, parameters);

                    return chapter;
                }
                catch (Exception ex)
                {

                    throw new($"Exception while trying to find the Chapter with the '{chapterName}'. The exception was: '{ex.Message}'", ex);
                }

            }
        }

        public async Task<Chapter> InsertChapterAsync(Chapter chapter)
        {
            string commandText = "INSERT INTO Chapters (ChapterName, FKSubjectId, ChapterDescription) VALUES (@ChapterName, @FKSubjectId, @ChapterDescription); SELECT CAST(scope_identity() AS int)";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {

                var insertParameters = new
                {
                    ChapterName = chapter.Name,
                    FKSubjectId = chapter.FKSubjectId,
                    ChapterDescription = chapter.Description
                };


                try
                {
                    await connection.ExecuteAsync(commandText, insertParameters);
                    chapter.Id = (int)await connection.ExecuteScalarAsync(commandText, insertParameters);
                    return chapter;
                }
                catch (Exception ex)
                {

                    throw new($"Exception while trying to insert a Chapter object. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task UpdateChapterAsync(Chapter chapter)
        {
            string commandText = "UPDATE Chapter " +
                "SET ChapterName = @ChapterName, " +
                "FKSubjectId = @FKSubjectId, " +
                "ChapterDescription = @ChapterDescription " +
                "WHERE ChapterId = @ChapterId";

            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                var parameters = new
                {
                    ChapterName = chapter.Name,
                    FKSubjectId = chapter.FKSubjectId,
                    ChapterDescription = chapter.Description,
                    ChapterId = chapter.Id
                };

                try
                {
                await connection.ExecuteAsync(commandText, parameters);

                }
                catch (Exception ex)
                {

                    throw new Exception($"Exception while trying to update chapter. The exception was: '{ex.Message}'", ex);
                }
            }
        }
    }
}
