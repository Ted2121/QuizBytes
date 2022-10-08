using Dapper;
using DataAccessDefinitionLibrary;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.DAO_models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SQLAccessImplementationLibrary
{
    public class CourseDataAccess : ICourseDataAccess
    {
        public async Task DeleteCourseAsync(CourseModel course)
        {
            string commandText = "DELETE FROM Courses WHERE CourseId = @CourseId";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                var parameters = new
                {
                    CourseId = course.Id
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to delete a row from Courses table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<CourseModel>> GetAllCoursesAsync()
        {
            string commandText = " SELECT * FROM Courses";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                try
                {
                    var courses = await connection.QueryAsync<CourseModel>(commandText);

                    return courses;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Courses table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<CourseModel> GetByIdAsync(int courseId)
        {
            string commandText = "SELECT * FROM Courses WHERE CourseId = @CourseId";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                var parameters = new
                {
                    CourseId = courseId
                };

                try
                {
                    var course = await connection.QuerySingleOrDefaultAsync<CourseModel>(commandText, parameters);

                    return course;
                }
                catch (Exception ex)
                {

                    throw new($"Exception while trying to find the Course with the '{courseId}'. The exception was: '{ex.Message}'", ex);
                }

            }
        }

        public async Task<CourseModel> InsertAsync(CourseModel course)
        {
            string commandText = "INSERT INTO Courses (CourseName, CourseDescription) VALUES (@CourseName, @CourseDescription); SELECT CAST(scope_identity() AS int)";

            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                var insertParameters = new
                {
                    CourseName = course.Name,
                    CourseDescription = course.Description
                };

                try
                {
                    await connection.ExecuteAsync(commandText, insertParameters);
                    course.Id = (int)await connection.ExecuteScalarAsync(commandText, insertParameters);
                    return course;
                }
                catch (Exception ex)
                {
                    throw new($"Exception while trying to insert a Course object. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task UpdateCourseAsync(CourseModel course)
        {
            string commandText = "UPDATE Courses " +
                 "SET CourseName = @CourseName, " +
                 "CourseDescription = @CourseDescription " +
                 "WHERE CourseId = @CourseId";

            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                var parameters = new
                {
                    CourseName = course.Name,
                    CourseDescription = course.Description,
                    CourseId = course.Id
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);

                }
                catch (Exception ex)
                {

                    throw new Exception($"Exception while trying to update Course. The exception was: '{ex.Message}'", ex);
                }
            }
        }
    }
}
