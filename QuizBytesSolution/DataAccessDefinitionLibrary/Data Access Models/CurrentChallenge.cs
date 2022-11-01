using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDefinitionLibrary.Data_Access_Models
{
    public class CurrentChallenge
    {
        public int CurrentChallengeId { get; set; }
        public Course course { get; set; }
        public int TimeInSeconds { get; set; }

    }
}
