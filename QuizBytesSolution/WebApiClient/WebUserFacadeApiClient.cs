using DataAccessDefinitionLibrary.DAO_Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.DTOs;
using WebApiClient.Extensions;

namespace WebApiClient;

public class WebUserFacadeApiClient : IWebUserFacadeApiClient
{
    private RestClient _restClient;

    public WebUserFacadeApiClient(string uri) => _restClient = new RestClient(uri);

    public async Task<IEnumerable<WebUserDto>> GetAllWebUsersAsync()
    {
        var response = await _restClient.RequestAsync<IEnumerable<WebUserDto>>(Method.GET, $"WebUser");

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error retrieving all web users. Message was {response.Content}");
        }

        return response.Data;
    }

    public async Task<int> CreateWebUserAsync(WebUserDto webUser)
    {
        var response = await _restClient.RequestAsync<int>(Method.POST, $"WebUser", webUser);

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error creating the web user. Message was {response.Content}");
        }

        return response.Data;

    }

    public async Task<WebUserDto> GetWebUserByUsernameAsync(string username)
    {
        var response = await _restClient.RequestAsync<WebUserDto>(Method.GET, $"WebUser/{username}");

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error retrieving the web user with the username {username}. Message was {response.Content}");
        }

        return response.Data;

    }

    public async Task<bool> UpdateWebUserAsync(WebUserDto webUser)
    {
        var response = await _restClient.RequestAsync(Method.PUT, $"WebUser", webUser);

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error updating the web user. Message was {response.Content}");
        }

        return true;
    }

    public async Task<bool> UpdatePasswordAsync(WebUserDto webUser)
    {
        var response = await _restClient.RequestAsync(Method.PUT, $"WebUser/password", webUser);

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error updating password. Message was {response.Content}");
        }

        return true;

    }

    public async Task<WebUserDto> GetWebUserByIdAsync(int id)
    {
        var response = await _restClient.RequestAsync<WebUserDto>(Method.GET, $"WebUser/{id}");

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error getting the web user by id. Message was {response.Content}");
        }

        return response.Data;
    }

    public async Task<bool> DeleteWebUserAsync(int id)
    {
        var response = await _restClient.RequestAsync(Method.DELETE, $"WebUser/{id}");

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error deleting the web user. Message was {response.Content}");
        }

        return true;
    }

    public async Task<IEnumerable<ChapterDto>> GetUnlockedChaptersOfWebUserAsync(WebUserDto webUser)
    {
        var response = await _restClient.RequestAsync<IEnumerable<ChapterDto>>(Method.GET, $"WebUserChapterUnlocks/webuser", webUser);

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error getting web user's unlocked chapters. Message was {response.Content}");
        }

        return response.Data;
    }

    public async Task<bool> UnlockChapterAsync(WebUserChapterUnlockDto webUserChapterUnlock)
    {
        var response = await _restClient.RequestAsync(Method.POST, $"WebUserChapterUnlocks/unlock", webUserChapterUnlock);

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error unlocking chapter. Message was {response.Content}");
        }

        return true;
    }

}
