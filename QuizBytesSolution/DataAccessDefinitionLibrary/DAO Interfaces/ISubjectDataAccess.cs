using DataAccessDefinitionLibrary.DAO_models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface ISubjectDataAccess
    {
        Task<SubjectModel> InsertAsync(SubjectModel subject);
        Task<SubjectModel> GetByIdAsync(int id);
        Task<IEnumerable<SubjectModel>> GetAllSubjectsAsync();
        Task<IEnumerable<SubjectModel>> GetAllSubjectsByCourseAsync(CourseModel course);
        Task<bool> UpdateSubjectAsync(SubjectModel subject);
        Task<bool> DeleteSubjectAsync(SubjectModel subject);
    }
}
