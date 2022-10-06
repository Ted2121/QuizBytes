using Dapper;
using DataAccessDefinitionLibrary;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.DAO_models;
using System.Data.SqlClient;

namespace SQLAccessImplementationLibrary
{
    public class ChapterDataAccess : IChapterDataAccess
    {


        public async Task DeleteChapterAsync(ChapterModel chapter)
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

        public async Task<IEnumerable<ChapterModel>> GetAllChaptersAsync()
        {
            string commandText = " SELECT* FROM Chapters";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                try
                {
                    var chapters = await connection.QueryAsync<ChapterModel>(commandText);

                    return chapters;
                }
                catch(Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Chapters table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<ChapterModel>> GetAllChaptersBySubjectAsync(SubjectModel subject)
        {
            string commandText = "SELECT * FROM Chapters WHERE FKSubjectId = @FKSubjectId";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {

                try
                {
                    var parameters = new
                    {
                        SubjectId = subject.Id
                    };

                    var chapters = await connection.QueryAsync<ChapterModel>(commandText, parameters);

                    return chapters;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Chapters table with the foreign key attribute: FKSubjectId = {subject.Id}. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<ChapterModel> GetByIdAsync(int chapterId)
        {
            string commandText = "SELECT * FROM Chapters WHERE ChapterId = @ChapterId";
                using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                var parameters = new
                {
                    ChapterId = chapterId
                };

                var chapter = await connection.QuerySingleOrDefaultAsync<ChapterModel>(commandText, parameters);

                return chapter;

            }
        }

        public Task<ChapterModel> InsertAsync(ChapterModel chapter)
        {
            string commandText = "INSERT INTO Chapters (ChapterId, ChapterName, FKSubjectId, ChapterDescription) VALUES (@ChapterId, @ChapterName, @FKSubjectId, @ChapterDescription);";
        }

        public Task<bool> UpdateChapterAsync(ChapterModel chapter)
        {
            throw new NotImplementedException();
        }
    }
}
