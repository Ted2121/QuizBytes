using WebApiClient.DTOs;

namespace WebApiClient
{
    public interface IChallengeFacadeApiClient
    {
        Task<bool> CheckIfUserIsInChallengeAsync(int webUserId);
        Task<bool> ClearTempTableBeforeNextChallengeAsync();
        Task<bool> DeregisterParticipantAsync(int id);
        Task<bool> DistributeRewardsAsync();
        Task<IEnumerable<CurrentChallengeParticipantDto>> GetAllParticipantsAsync();
        Task<QuizDto> GetChallengeQuizAsync(CourseDto course);
        Task<int> GetNumberOfParticipantsAsync();
        Task<int> RegisterParticipantAsync(WebUserDto webUser, CourseDto course);
    }
}