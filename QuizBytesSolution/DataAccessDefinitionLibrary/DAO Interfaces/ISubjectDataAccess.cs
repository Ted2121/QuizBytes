using DataAccessDefinitionLibrary.Data_Access_Models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface ISubjectDataAccess
    {
        Task<int> InsertSubjectAsync(Subject subject);
        Task<Subject> GetSubjectByIdAsync(int subjectId);
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Task<IEnumerable<Subject>> GetAllSubjectsByCourseAsync(Course course);
        Task<bool> UpdateSubjectAsync(Subject subject);
        Task<bool> DeleteSubjectAsync(int subjectId);
    }
}
