using QuizBytesAPIServer.DTOs;

namespace QuizBytesAPIServer.Helper_Classes;

public interface IRewardsDistributionHelper
{
    Task DistributeChallengeRewardsAsync(List<CurrentChallengeParticipantDto> leaderboard);
    Task DistributeQuizRewardsAsync(WebUserDto webUserDto);
}