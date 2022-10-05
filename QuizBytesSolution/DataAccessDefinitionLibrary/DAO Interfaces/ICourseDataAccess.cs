using DataAccessDefinitionLibrary.DAO_models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface ICourseDataAccess
    {
        void Insert(CourseModel course);
        CourseModel GetById(int id);
        IEnumerable<CourseModel> GetAllCourses();
        bool UpdateCourse(CourseModel course);
        bool DeleteCourse(CourseModel course);
    }
}
