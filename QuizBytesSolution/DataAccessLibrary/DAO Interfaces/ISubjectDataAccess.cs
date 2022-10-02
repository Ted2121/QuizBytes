using DataAccessLibrary.Data_Access_Models;
using DataAccessLibrary.Data_Access_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DAO_Interfaces
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
