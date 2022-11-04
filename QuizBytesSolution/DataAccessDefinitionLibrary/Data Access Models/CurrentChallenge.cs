using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDefinitionLibrary.Data_Access_Models
{
    public class CurrentChallenge
    {

        public int PKCurrentChallengeId { get; set; }
        public int FKWebUserId { get; set; }
        public int FKCourseId { get; set; }
        
        public CurrentChallenge(string connectionstring)
        {
        }

        public CurrentChallenge()
        {
        }
    }
}
