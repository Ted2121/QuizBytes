using DataAccessDefinitionLibrary.Data_Access_Models;
using QuizBytesAPIServer.DTOs;

namespace QuizBytesAPIServer.Helper_Classes;

public interface IRewardsDistributionHelper
{
    Task<IEnumerable<CurrentChallengeParticipant>> BuildLeaderboardFromParticipantList(IEnumerable<CurrentChallengeParticipant> currentChallengeEntries);
    Task DistributeChallengeRewardsAsync(List<CurrentChallengeParticipantDto> leaderboard);
    Task DistributeQuizRewardsAsync(WebUserDto webUserDto);
}