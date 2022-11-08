using QuizBytesAPIServer.DTOs;

namespace QuizBytesAPIServer.Helper_Classes
{
    public interface IRewardsDistributionHelper
    {
        Task DistributeChallengeRewards(List<CurrentChallengeParticipantDto> leaderboard);
        Task DistributeQuizRewards(WebUserDto webUser);
    }
}