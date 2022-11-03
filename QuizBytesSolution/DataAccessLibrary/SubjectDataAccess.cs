using Dapper;
using DataAccessDefinitionLibrary;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System.Data.SqlClient;

namespace SQLAccessImplementationLibrary
{
    public class SubjectDataAccess : BaseDataAccess, ISubjectDataAccess
    {
        public SubjectDataAccess(string connectionstring) : base(connectionstring)
        {
        }

        public async Task DeleteSubjectAsync(Subject subject)
        {
            string commandText = "DELETE FROM Subject WHERE PKSubjectId = @PKSubjectId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    PKSubjectId = subject.PKSubjectId
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to delete a row from Subject table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            string commandText = " SELECT * FROM Subject";
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    var subjects = await connection.QueryAsync<Subject>(commandText);

                    return subjects;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Subject table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsByCourseAsync(Course course)
        {
            string commandText = "SELECT * FROM Subject WHERE FKCourseId = @FKCourseId";
            using (SqlConnection connection = CreateConnection())
            {

                try
                {
                    var parameters = new
                    {
                        FKCourseId = course.PKCourseId
                    };

                    var subjects = await connection.QueryAsync<Subject>(commandText, parameters);

                    return subjects;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Subject table with the foreign key attribute: FKCourseId = {course.PKCourseId}. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<Subject> GetSubjectByIdAsync(int subjectId)
        {
            string commandText = "SELECT * FROM Subject WHERE PKSubjectId = @PKSubjectId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    PKSubjectId = subjectId
                };

                try
                {
                    var subject = await connection.QuerySingleOrDefaultAsync<Subject>(commandText, parameters);

                    return subject;
                }
                catch (Exception ex)
                {

                    throw new($"Exception while trying to find the Subject with the '{subjectId}'. The exception was: '{ex.Message}'", ex);
                }

            }
        }

        public async Task<Subject> InsertSubjectAsync(Subject subject)
        {
            string commandText = "INSERT INTO Subject (Name, FKCourseId, Description) VALUES (@Name, @FKCourseId, @Description); SELECT CAST(scope_identity() AS int)";

            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    Name = subject.Name,
                    FKCourseId = subject.FKCourseId,
                    Description = subject.Description
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                    subject.PKSubjectId = (int)await connection.ExecuteScalarAsync(commandText, parameters);
                    return subject;
                }
                catch (Exception ex)
                {
                    throw new($"Exception while trying to insert a Subject object. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task UpdateSubjectAsync(Subject subject)
        {
            string commandText = "UPDATE Subject " +
                "SET Name = @Name, " +
                "FKCourseId = @FKCourseId, " +
                "Description = @Description " +
                "WHERE PKSubjectId = @PKSubjectId";

            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    Name = subject.Name,
                    FKCourseId = subject.FKCourseId,
                    Description = subject.Description,
                    PKSubjectId = subject.PKSubjectId
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);

                }
                catch (Exception ex)
                {

                    throw new Exception($"Exception while trying to update Subject. The exception was: '{ex.Message}'", ex);
                }
            }
        }
    }
}
