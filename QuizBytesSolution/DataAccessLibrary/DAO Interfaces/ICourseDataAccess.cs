using DataAccessLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DAO_Interfaces
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
