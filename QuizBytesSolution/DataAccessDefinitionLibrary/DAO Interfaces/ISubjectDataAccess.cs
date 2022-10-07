using DataAccessDefinitionLibrary.DAO_models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface ISubjectDataAccess
    {
        Task<SubjectModel> InsertAsync(SubjectModel subject);
        Task<SubjectModel> GetByIdAsync(int subjectId);
        Task<IEnumerable<SubjectModel>> GetAllSubjectsAsync();
        Task<IEnumerable<SubjectModel>> GetAllSubjectsByCourseAsync(CourseModel course);
        Task UpdateSubjectAsync(SubjectModel subject);
        Task DeleteSubjectAsync(SubjectModel subject);
    }
}
