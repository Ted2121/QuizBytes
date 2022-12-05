using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApiClient.DTOs;

namespace WindowsApiClient
{
    public class SubjectFacadeApiClient : ISubjectFacadeApiClient
    {
        private RestClient _restClient;

        public SubjectFacadeApiClient(string uri) => _restClient = new RestClient(uri);

        public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            var response = await _restClient.RequestAsync<IEnumerable<SubjectDto>>(Method.GET, $"Subjects");

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error retrieving all subjects. Message was {response.Content}");
            }

            return response.Data;
        }
    }
}
