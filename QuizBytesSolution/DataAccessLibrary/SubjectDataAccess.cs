using Dapper;
using DataAccessDefinitionLibrary;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.DAO_models;
using System.Data.SqlClient;

namespace SQLAccessImplementationLibrary
{
    public class SubjectDataAccess : ISubjectDataAccess
    {
        public async Task DeleteSubjectAsync(SubjectModel subject)
        {
            string commandText = "DELETE FROM Subjects WHERE SubjectId = @SubjectId";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
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

        public async Task<IEnumerable<SubjectModel>> GetAllSubjectsAsync()
        {
            string commandText = " SELECT * FROM Subjects";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                try
                {
                    var subjects = await connection.QueryAsync<SubjectModel>(commandText);

                    return subjects;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Subjects table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<SubjectModel>> GetAllSubjectsByCourseAsync(CourseModel course)
        {
            string commandText = "SELECT * FROM Subjects WHERE FKCourseId = @FKCourseId";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {

                try
                {
                    var parameters = new
                    {
                        FKCourseId = course.Id
                    };

                    var subjects = await connection.QueryAsync<SubjectModel>(commandText, parameters);

                    return subjects;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Subjects table with the foreign key attribute: FKCourseId = {course.Id}. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<SubjectModel> GetByIdAsync(int subjectId)
        {
            string commandText = "SELECT * FROM Subjects WHERE SubjectId = @SubjectId";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                var parameters = new
                {
                    SubjectId = subjectId
                };

                try
                {
                    var subject = await connection.QuerySingleOrDefaultAsync<SubjectModel>(commandText, parameters);

                    return subject;
                }
                catch (Exception ex)
                {

                    throw new($"Exception while trying to find the Subject with the '{subjectId}'. The exception was: '{ex.Message}'", ex);
                }

            }
        }

        public async Task<SubjectModel> InsertAsync(SubjectModel subject)
        {
            string commandText = "INSERT INTO Subjects (SubjectName, FKCourseId, SubjectDescription) VALUES (@SubjectName, @FKCourseId, @SubjectDescription); SELECT CAST(scope_identity() AS int)";

            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
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

        public async Task UpdateSubjectAsync(SubjectModel subject)
        {
            string commandText = "UPDATE Subject " +
                "SET SubjectName = @SubjectName, " +
                "FKCourseId = @FKCourseId, " +
                "SubjectDescription = @SubjectDescription " +
                "WHERE SubjectId = @SubjectId";

            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
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
