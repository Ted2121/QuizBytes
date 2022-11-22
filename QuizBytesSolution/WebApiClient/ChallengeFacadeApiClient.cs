using Microsoft.JSInterop;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApiClient.DTOs;
using WebApiClient.Extensions;

namespace WebApiClient
{
    public class ChallengeFacadeApiClient : IChallengeFacadeApiClient
    {
        private RestClient _restClient;

        public ChallengeFacadeApiClient(string uri) => _restClient = new RestClient(uri);

        public async Task<IEnumerable<CurrentChallengeParticipantDto>> GetAllParticipantsAsync()
        {
            var response = await _restClient.RequestAsync<IEnumerable<CurrentChallengeParticipantDto>>(Method.GET, $"Challenge/participants");

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error retrieving all participants. Message was {response.Content}");
            }

            return response.Data;
        }

        public async Task<bool> DeregisterParticipantAsync(int id)
        {
            var response = await _restClient.RequestAsync(Method.DELETE, $"Challenge/{id}");

            if (response.IsSuccessful)
            {
                return true;
            }
            else
            {
                throw new Exception($"Error deleting participant with id={id}. Message was {response.Content}");
            }
        }

        public async Task<bool> DistributeRewardsAsync(LeaderboardDto leaderboard)
        {
            var response = await _restClient.RequestAsync(Method.PUT, $"Challenge/rewards", leaderboard);

            if (response.IsSuccessful)
            {
                return true;
            }
            else
            {
                throw new Exception($"Error distributing rewards for the current challenge. Message was {response.Content}");
            }
        }

        public async Task<bool> ClearTempTableBeforeNextChallengeAsync()
        {
            var response = await _restClient.RequestAsync(Method.DELETE, $"Challenge/cleartable");

            if (response.IsSuccessful)
            {

                return true;

            }
            else
            {
                throw new Exception($"Error clearing the current challenge table. Message was {response.Content}");
            }
        }

        public async Task<int> RegisterParticipantAsync(WebUserDto webUser, CourseDto course)
        {
            var resource = new CurrentChallengeParticipantDto() { WebUser = webUser, Course = course };
            var response = await _restClient.RequestAsync<int>(Method.POST, $"Challenge", resource);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error registering participant. Message was {response.Content}");
            }
            else
            {
                return response.Data;
            }

        }

        public async Task<int> GetNumberOfParticipantsAsync()
        {
            var response = await _restClient.RequestAsync<int>(Method.GET, $"/Challenge/count");

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error getting the number of participants in the challenge. Message was: {response.Content}");
            }
            
                return response.Data;
            
        }

        public async Task<QuizDto> GetChallengeQuizAsync(CourseDto course)
        {
            var response = await _restClient.RequestAsync<QuizDto>(Method.GET, $"Challenge/quiz", course);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error getting the quiz. Message was: {response.Content}");
            }
            else
            {
                return response.Data;
            }
        }

        public async Task<bool> CheckIfUserIsInChallengeAsync(int id)
        {
            var response = await _restClient.RequestAsync<bool>(Method.GET, $"Challenge/{id}", id);

            if (!response.IsSuccessful)
            {
                return false;
            }
            else
            {
                return response.Data;
            }
        }
    }
}
