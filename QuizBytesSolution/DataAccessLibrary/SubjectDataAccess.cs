using Dapper;
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

        public async Task<bool> DeleteSubjectAsync(int subjectId)
        {
            try
            {
                string commandText = "DELETE FROM Subject WHERE PKSubjectId = @PKSubjectId";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        PKSubjectId = subjectId
                    };

                    return await connection.ExecuteAsync(commandText, parameters) > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to delete a row from Subject table. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            try
            {
                string commandText = " SELECT * FROM Subject";
                using (SqlConnection connection = CreateConnection())
                {
                    var subjects = await connection.QueryAsync<Subject>(commandText);

                    return subjects;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to read all rows from the Subject table. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsByCourseAsync(Course course)
        {
            try
            {
                string commandText = "SELECT * FROM Subject WHERE FKCourseId = @FKCourseId";
                using (SqlConnection connection = CreateConnection())
                {

                    var parameters = new
                    {
                        FKCourseId = course.PKCourseId
                    };

                    var subjects = await connection.QueryAsync<Subject>(commandText, parameters);

                    return subjects;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to read all rows from the Subject table with the foreign key attribute: FKCourseId = {course.PKCourseId}. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<Subject> GetSubjectByIdAsync(int subjectId)
        {
            try
            {
                string commandText = "SELECT * FROM Subject WHERE PKSubjectId = @PKSubjectId";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        PKSubjectId = subjectId
                    };

                    var subject = await connection.QuerySingleOrDefaultAsync<Subject>(commandText, parameters);

                    return subject;
                }
            }
            catch (SqlException ex)
            {

                throw new($"Exception while trying to find the Subject with the '{subjectId}'. The exception was: '{ex.Message}'", ex);


            }
        }

        public async Task<int> InsertSubjectAsync(Subject subject)
        {
            try
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

                    return subject.PKSubjectId = await connection.QuerySingleAsync<int>(commandText, parameters);
                }
            }
            catch (SqlException ex)
            {
                throw new($"Exception while trying to insert a Subject object. The exception was: '{ex.Message}'", ex);

            }
        }

        public async Task<bool> UpdateSubjectAsync(Subject subject)
        {
            try
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

                    return await connection.ExecuteAsync(commandText, parameters) > 0;

                }
            }
            catch (SqlException ex)
            {

                throw new Exception($"Exception while trying to update Subject. The exception was: '{ex.Message}'", ex);

            }
        }
    }
}
