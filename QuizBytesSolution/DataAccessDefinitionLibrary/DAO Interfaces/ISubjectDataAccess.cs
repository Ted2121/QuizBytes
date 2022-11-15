using DataAccessDefinitionLibrary.Data_Access_Models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface ISubjectDataAccess
    {
        Task<Subject> InsertSubjectAsync(Subject subject);
        Task<Subject> GetSubjectByIdAsync(int subjectId);
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Task<IEnumerable<Subject>> GetAllSubjectsByCourseAsync(Course course);
        Task<bool> UpdateSubjectAsync(Subject subject);
        Task<bool> DeleteSubjectAsync(int subjectId);
    }
}
