using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessDefinitionLibrary.Data_Access_Models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface IWebUserChapterUnlockDataAccess
    {
        Task InsertWebUserChapterUnlockAsync(WebUser webUser, Chapter chapter);
        Task<IEnumerable<WebUserChapterUnlock>> GetAllWebUserChapterUnlocksAsync();
        Task<IEnumerable<WebUserChapterUnlock>> GetAllWebUserChapterUnlocksByWebUserAsync(WebUser webUser);
        Task<IEnumerable<WebUserChapterUnlock>> GetAllWebUserChapterUnlocksByChapterAsync(Chapter chapter);
        Task DeleteWebUserChapterUnlockAsync(WebUserChapterUnlock webUserChapterUnlock);
    }
}
