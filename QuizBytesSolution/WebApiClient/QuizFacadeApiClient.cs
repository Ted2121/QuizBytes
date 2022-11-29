using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.DTOs;
using WebApiClient.Extensions;

namespace WebApiClient;

public class QuizFacadeApiClient
{
    private RestClient _restClient;

    public QuizFacadeApiClient(string uri) => _restClient = new RestClient(uri);

    public async Task<ChapterDto> GetChapterByIdAsync(int id)
    {
        var response = await _restClient.RequestAsync<ChapterDto>(Method.GET, $"Chapters/{id}");

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error getting the chapter with id {id}. Message was {response.Content}");
        }

        return response.Data;
    }
}
