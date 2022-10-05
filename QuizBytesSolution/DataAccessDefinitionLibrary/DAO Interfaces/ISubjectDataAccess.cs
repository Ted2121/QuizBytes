using DataAccessDefinitionLibrary.DAO_models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface ISubjectDataAccess
    {
        void Insert(SubjectModel subject);
        SubjectModel GetById(int id);
        IEnumerable<SubjectModel> GetAllSubjects();
        IEnumerable<SubjectModel> GetAllSubjectsByCourse(CourseModel course);
        bool UpdateSubject(SubjectModel subject);
        bool DeleteSubject(SubjectModel subject);
    }
}
