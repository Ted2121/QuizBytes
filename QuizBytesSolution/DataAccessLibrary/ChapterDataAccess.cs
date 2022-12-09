using Dapper;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System.Data.SqlClient;

namespace SQLAccessImplementationLibrary
{
    public class ChapterDataAccess : BaseDataAccess, IChapterDataAccess
    {
        public ChapterDataAccess(string connectionstring) : base(connectionstring)
        {
        }

        public async Task<bool> DeleteChapterAsync(int chapterId)
        {
            try
            {
                string commandText = "DELETE FROM Chapter WHERE Id = @Id";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        Id = chapterId
                    };


                    return await connection.ExecuteAsync(commandText, parameters) > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception while trying to delete a row from Chapter table. The exception was: '{ex.Message}'", ex);
            }


        }

        public async Task<IEnumerable<Chapter>> GetAllChaptersAsync()
        {
            try
            {
                string commandText = "SELECT* FROM Chapter";
                using (SqlConnection connection = CreateConnection())
                {
                    var chapters = await connection.QueryAsync<Chapter>(commandText);

                    return chapters;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception while trying to read all rows from the Chapter table. The exception was: '{ex.Message}'", ex);
            }

        }

        public async Task<IEnumerable<Chapter>> GetAllChaptersBySubjectAsync(Subject subject)
        {
            try
            {
                string commandText = "SELECT * FROM Chapter WHERE FKSubjectId = @FKSubjectId";
                using (SqlConnection connection = CreateConnection())
                {

                    var parameters = new
                    {
                        FKSubjectId = subject.Id
                    };

                    var chapters = await connection.QueryAsync<Chapter>(commandText, parameters);

                    return chapters;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception while trying to read all rows from the Chapter table with the foreign key attribute: FKSubjectId = {subject.Id}. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<Chapter> GetChapterByIdAsync(int chapterId)
        {
            try
            {
                string commandText = "SELECT * FROM Chapter WHERE Id = @Id";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        Id = chapterId
                    };

                    var chapter = await connection.QuerySingleOrDefaultAsync<Chapter>(commandText, parameters);

                    return chapter;
                }
            }
            catch (Exception ex)
            {

                throw new($"Exception while trying to find the Chapter with the '{chapterId}'. The exception was: '{ex.Message}'", ex);


            }
        }

        public async Task<Chapter> GetChapterByNameAsync(string chapterName)
        {
            try
            {
                string commandText = "SELECT * FROM Chapter WHERE Name = @Name";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        Name = chapterName
                    };

                    var chapter = await connection.QuerySingleOrDefaultAsync<Chapter>(commandText, parameters);

                    return chapter;
                }
            }
            catch (Exception ex)
            {

                throw new($"Exception while trying to find the Chapter with the '{chapterName}'. The exception was: '{ex.Message}'", ex);


            }
        }

        public async Task<int> InsertChapterAsync(Chapter chapter)
        {
            try
            {
                string commandText = "INSERT INTO Chapter (Name, FKSubjectId, Description) VALUES (@Name, @FKSubjectId, @Description); SELECT CAST(scope_identity() AS int)";
                using (SqlConnection connection = CreateConnection())
                {

                    var parameters = new
                    {
                        Name = chapter.Name,
                        FKSubjectId = chapter.FKSubjectId,
                        Description = chapter.Description
                    };

                    var chapterId = await connection.QuerySingleAsync<int>(commandText, parameters);
                    //return chapter.Id = await connection.QuerySingleAsync<int>(commandText, parameters);
                    return chapterId;
                }
            }
            catch (Exception ex)
            {

                throw new($"Exception while trying to insert a Chapter object. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<bool> UpdateChapterAsync(Chapter chapter)
        {
            try
            {
                string commandText = "UPDATE Chapter " +
                    "SET Name = @Name, " +
                    "FKSubjectId = @FKSubjectId, " +
                    "Description = @Description " +
                    "WHERE Id = @Id";

                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        Name = chapter.Name,
                        FKSubjectId = chapter.FKSubjectId,
                        Description = chapter.Description,
                        Id = chapter.Id
                    };

                    return await connection.ExecuteAsync(commandText, parameters) > 0;

                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception while trying to update chapter. The exception was: '{ex.Message}'", ex);

            }
        }
    }
}
