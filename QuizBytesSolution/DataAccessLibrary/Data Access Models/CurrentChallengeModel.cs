using DataAccessLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data_Access_Objects
{
    public class CurrentChallengeModel
    {
        public IEnumerable<(WebUserModel, CourseModel)> RegisteredUserCoursePairs { get; set; }
        public int MyProperty { get; set; }
    }
}
