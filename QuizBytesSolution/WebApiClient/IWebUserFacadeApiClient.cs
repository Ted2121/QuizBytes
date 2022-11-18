using WebApiClient.DTOs;

namespace WebApiClient
{
    public interface IWebUserFacadeApiClient
    {
        Task<int> CreateWebUserAsync(WebUserDto webUser);
        Task<bool> DeleteWebUserAsync(int id);
        Task<IEnumerable<WebUserDto>> GetAllWebUsersAsync();
        Task<IEnumerable<ChapterDto>> GetUnlockedChaptersOfWebUserAsync(WebUserDto webUser);
        Task<WebUserDto> GetWebUserByIdAsync(int id);
        Task<WebUserDto> GetWebUserByUsernameAsync(string username);
        Task<bool> UnlockChapterAsync(WebUserChapterUnlockDto webUserChapterUnlock);
        Task<bool> UpdatePasswordAsync(WebUserDto webUser);
        Task<bool> UpdateWebUserAsync(WebUserDto webUser);
    }
}