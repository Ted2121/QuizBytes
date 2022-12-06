using System;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApiClient.DTOs;



namespace WindowsApiClient
{
    public class ChapterFacadeApiClient : IChapterFacadeApiClient
    {
        private RestClient _restClient;

        public ChapterFacadeApiClient(string uri) => _restClient = new RestClient(uri);

        public async Task<IEnumerable<ChapterDto>> GetAllChaptersAsync()
        {
            var response = await _restClient.RequestAsync<IEnumerable<ChapterDto>>(Method.GET, $"Chapters");

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error retrieving all chapters. Message was {response.Content}");
            }

            return response.Data;
        }

        public async Task<IEnumerable<ChapterDto>> GetAllChaptersBySubjectAsync(SubjectDto subject)
        {
            var response = await _restClient.RequestAsync<IEnumerable<ChapterDto>>(Method.GET, $"Chapters/{subject}");

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error getting the chapters with subject {subject}. Message was {response.Content}");
            }

            return response.Data;
        }

        public async Task<ChapterDto> GetChapterByIdAsync(int id)
        {
            var response = await _restClient.RequestAsync<ChapterDto>(Method.GET, $"Chapters/{id}");

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error getting the chapter with id {id}. Message was {response.Content}");
            }

            return response.Data;
        }

        public async Task<bool> DeleteChapterAsync(int id)
        {
            var response = await _restClient.RequestAsync(Method.DELETE, $"Chapters/{id}");

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error deleting the chapter. Message was {response.Content}");
            }

            return true;
        }

        public async Task<int> InsertChapterAsync(ChapterDto chapter)
        {
            var response = await _restClient.RequestAsync<int>(Method.POST, $"Chapters", chapter);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error inserting the chapter. Message was {response.Content}");
            }

            return response.Data;
        }

        public async Task<bool> UpdateChapterAsync(ChapterDto chapter)
        {
            var response = await _restClient.RequestAsync(Method.PUT, $"Chapters", chapter);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error updating the chapter. Message was {response.Content}");
            }

            return true;
        }

    }
}
