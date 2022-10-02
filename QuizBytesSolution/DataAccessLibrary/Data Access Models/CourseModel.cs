using DataAccessLibrary.Data_Access_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data_Access_Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentChallengeId { get; set; }
        public CurrentChallengeModel CurrentChallenge { get; set; }
        public IEnumerable<SubjectModel> Subjects { get; set; }
    }
}
