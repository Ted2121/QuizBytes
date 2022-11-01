using DataAccessDefinitionLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface ICurrentChallengeDataAccess
    {
        Task AddWebUserToChallengeAsync(WebUser webuser, Course course);
        Task DeleteWebUserFromChallengeAsync(WebUser webuser);
        Task<IEnumerable<WebUser>> GetAllUsersInChallengeAsync();
        Task ResetTempTableBeforeNextChallengeAsync();
    }
}
