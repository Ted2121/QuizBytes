using Dapper;
using DataAccessDefinitionLibrary;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.DAO_models;
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
            string commandText = "DELETE FROM Subjects WHERE SubjectId = @SubjectId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    SubjectId = subject.Id
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to delete a row from Subjects table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            string commandText = " SELECT * FROM Subjects";
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    var subjects = await connection.QueryAsync<Subject>(commandText);

                    return subjects;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Subjects table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsByCourseAsync(Course course)
        {
            string commandText = "SELECT * FROM Subjects WHERE FKCourseId = @FKCourseId";
            using (SqlConnection connection = CreateConnection())
            {

                try
                {
                    var parameters = new
                    {
                        FKCourseId = course.Id
                    };

                    var subjects = await connection.QueryAsync<Subject>(commandText, parameters);

                    return subjects;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Subjects table with the foreign key attribute: FKCourseId = {course.Id}. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<Subject> GetSubjectByIdAsync(int subjectId)
        {
            string commandText = "SELECT * FROM Subjects WHERE SubjectId = @SubjectId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    SubjectId = subjectId
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
            string commandText = "INSERT INTO Subjects (SubjectName, FKCourseId, SubjectDescription) VALUES (@SubjectName, @FKCourseId, @SubjectDescription); SELECT CAST(scope_identity() AS int)";

            using (SqlConnection connection = CreateConnection())
            {
                var insertParameters = new
                {
                    SubjectName = subject.Name,
                    FKCourseId = subject.FKCourseId,
                    SubjectDescription = subject.Description
                };

                try
                {
                    await connection.ExecuteAsync(commandText, insertParameters);
                    subject.Id = (int)await connection.ExecuteScalarAsync(commandText, insertParameters);
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
            string commandText = "UPDATE Subjects " +
                "SET SubjectName = @SubjectName, " +
                "FKCourseId = @FKCourseId, " +
                "SubjectDescription = @SubjectDescription " +
                "WHERE SubjectId = @SubjectId";

            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    SubjectName = subject.Name,
                    FKCourseId = subject.FKCourseId,
                    SubjectDescription = subject.Description,
                    SubjectId = subject.Id
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
