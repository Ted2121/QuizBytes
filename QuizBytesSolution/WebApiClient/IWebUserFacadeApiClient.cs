﻿using WebApiClient.DTOs;

namespace WebApiClient;

public interface IWebUserFacadeApiClient
{
    Task<int> CreateWebUserAsync(WebUserDto webUser);
    Task<bool> DeleteWebUserAsync(int id);
    Task<IEnumerable<WebUserDto>> GetAllWebUsersAsync();
    Task<IEnumerable<ChapterDto>> GetUnlockedChaptersOfWebUserAsync(int webUserId);
    Task<WebUserDto> GetWebUserByIdAsync(int id);
    Task<WebUserDto> GetWebUserByUsernameAsync(string username);
    Task<WebUserDto> LoginUserAsync(WebUserDto webUser);
    Task<bool> UnlockChapterAsync(WebUserChapterUnlockDto webUserChapterUnlock);
    Task<bool> UpdatePasswordAsync(WebUserDto webUser);
    Task<bool> UpdateWebUserAsync(WebUserDto webUser);
}