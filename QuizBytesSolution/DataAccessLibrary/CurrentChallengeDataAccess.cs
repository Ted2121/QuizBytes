using DataAccessDefinitionLibrary.DAO_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAccessImplementationLibrary
{
    public class CurrentChallengeDataAccess : BaseDataAccess, ICurrentChallengeDataAccess
    {
        public CurrentChallengeDataAccess(string connectionstring) : base(connectionstring)
        {
        }
    }
}
