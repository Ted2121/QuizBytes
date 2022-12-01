using Dapper;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System.Data.SqlClient;

namespace SQLAccessImplementationLibrary
{
    public class CourseDataAccess : BaseDataAccess, ICourseDataAccess
    {
        public CourseDataAccess(string connectionstring) : base(connectionstring)
        {
        }

        public async Task<bool> DeleteCourseAsync(int courseId)
        {
            try
            {
                string commandText = "DELETE FROM Course WHERE Id = @Id";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        Id = courseId
                    };

                    return await connection.ExecuteAsync(commandText, parameters) > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception while trying to delete a row from Course table. The exception was: '{ex.Message}'", ex);
            }
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            try
            {
                string commandText = " SELECT * FROM Course";
                using (SqlConnection connection = CreateConnection())
                {
                    var courses = await connection.QueryAsync<Course>(commandText);

                    return courses;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception while trying to read all rows from the Course table. The exception was: '{ex.Message}'", ex);
            }
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            try
            {
                string commandText = "SELECT * FROM Course WHERE Id = @Id";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        Id = courseId
                    };

                    var course = await connection.QuerySingleOrDefaultAsync<Course>(commandText, parameters);

                    return course;
                }
            }
            catch (Exception ex)
            {
                throw new($"Exception while trying to find the Course with the '{courseId}'. The exception was: '{ex.Message}'", ex);
            }
        }

        public async Task<Course> GetCourseByNameAsync(string courseName)
        {
            try
            {
                string commandText = "SELECT * FROM Course WHERE Name = @Name";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        Name = courseName
                    };

                    var course = await connection.QuerySingleOrDefaultAsync<Course>(commandText, parameters);

                    return course;
                }
            }
            catch (Exception ex)
            {

                throw new($"Exception while trying to find the Course with the '{courseName}'. The exception was: '{ex.Message}'", ex);
            }
        }

        public async Task<int> InsertCourseAsync(Course course)
        {
            try
            {
                string commandText = "INSERT INTO Course (Name, Description) VALUES (@Name, @Description); SELECT CAST(scope_identity() AS int)";

                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        Name = course.Name,
                        Description = course.Description
                    };

                    return course.Id = await connection.QuerySingleAsync<int>(commandText, parameters);

                }

            }
            catch (Exception ex)
            {
                throw new($"Exception while trying to insert a Course object. The exception was: '{ex.Message}'", ex);
            }
        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            try
            {
                string commandText = "UPDATE Course " +
                     "SET Name = @Name, " +
                     "Description = @Description " +
                     "WHERE Id = @Id";

                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        Name = course.Name,
                        Description = course.Description,
                        Id = course.Id
                    };

                    return await connection.ExecuteAsync(commandText, parameters) > 0;

                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Exception while trying to update Course. The exception was: '{ex.Message}'", ex);

            }
        }
    }
}
