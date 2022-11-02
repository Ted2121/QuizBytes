using Dapper;
using DataAccessDefinitionLibrary;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SQLAccessImplementationLibrary
{
    public class CourseDataAccess : BaseDataAccess, ICourseDataAccess
    {
        public CourseDataAccess(string connectionstring) : base(connectionstring)
        {
        }

        public async Task DeleteCourseAsync(Course course)
        {
            string commandText = "DELETE FROM Course WHERE PKCourseId = @PKCourseId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    PKCourseId = course.PKCourseId
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to delete a row from Course table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            string commandText = " SELECT * FROM Course";
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    var courses = await connection.QueryAsync<Course>(commandText);

                    return courses;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Course table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            string commandText = "SELECT * FROM Course WHERE PKCourseId = @PKCourseId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    PKCourseId = courseId
                };

                try
                {
                    var course = await connection.QuerySingleOrDefaultAsync<Course>(commandText, parameters);

                    return course;
                }
                catch (Exception ex)
                {

                    throw new($"Exception while trying to find the Course with the '{courseId}'. The exception was: '{ex.Message}'", ex);
                }

            }
        }

        public async Task<Course> InsertCourseAsync(Course course)
        {
            string commandText = "INSERT INTO Course (Name, Description) VALUES (@Name, @Description); SELECT CAST(scope_identity() AS int)";

            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    Name = course.Name,
                    Description = course.Description
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                    course.PKCourseId = (int)await connection.ExecuteScalarAsync(commandText, parameters);
                    return course;
                }
                catch (Exception ex)
                {
                    throw new($"Exception while trying to insert a Course object. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task UpdateCourseAsync(Course course)
        {
            string commandText = "UPDATE Course " +
                 "SET Name = @Name, " +
                 "Description = @Description " +
                 "WHERE PKCourseId = @PKCourseId";

            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    Name = course.Name,
                    Description = course.Description,
                    PKCourseId = course.PKCourseId
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
