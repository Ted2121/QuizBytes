using DataAccessDefinitionLibrary.Data_Access_Models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces;

public interface ICourseDataAccess
{
    Task<int> InsertCourseAsync(Course course);
    Task<Course> GetCourseByIdAsync(int id);
    Task<IEnumerable<Course>> GetAllCoursesAsync();
    Task<bool> UpdateCourseAsync(Course course);
    Task<bool> DeleteCourseAsync(int id);
}
