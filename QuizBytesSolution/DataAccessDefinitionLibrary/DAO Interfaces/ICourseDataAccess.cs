using DataAccessDefinitionLibrary.DAO_models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface ICourseDataAccess
    {
        Task<CourseModel> InsertAsync(CourseModel course);
        Task<CourseModel> GetByIdAsync(int courseId);
        Task<IEnumerable<CourseModel>> GetAllCoursesAsync();
        Task UpdateCourseAsync(CourseModel course);
        Task DeleteCourseAsync(CourseModel course);
    }
}
