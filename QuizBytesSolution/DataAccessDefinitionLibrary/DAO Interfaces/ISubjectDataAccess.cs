using DataAccessDefinitionLibrary.DAO_models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface ISubjectDataAccess
    {
        Task<Subject> InsertSubjectAsync(Subject subject);
        Task<Subject> GetSubjectByIdAsync(int subjectId);
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Task<IEnumerable<Subject>> GetAllSubjectsByCourseAsync(Course course);
        Task UpdateSubjectAsync(Subject subject);
        Task DeleteSubjectAsync(Subject subject);
    }
}
