using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;

namespace QuizBytesAPIServer.Helper_Classes;

// TODO add total points as well
public class RewardsDistributionHelper : IRewardsDistributionHelper
{
    public IWebUserDataAccess WebUserDataAccess { get; set; }
    public RewardsDistributionHelper(
        IWebUserDataAccess webUserDataAccess)
    {
        WebUserDataAccess = webUserDataAccess;
    }

    public async Task DistributeChallengeRewardsAsync(List<CurrentChallengeParticipantDto> leaderboard)
    {
        int firstPlaceReward = 256;
        int secondPlaceReward = 128;
        int thirdPlaceReward = 64;
        int participationReward = 32;

        if (leaderboard[0] != null)
        {

            var firstPlaceUserDto = leaderboard[0].WebUser;

            firstPlaceUserDto.AvailablePoints += firstPlaceReward;
            firstPlaceUserDto.AvailablePoints += CalculateRewardsForQuiz(firstPlaceUserDto);

            await WebUserDataAccess.UpdateWebUserAsync(firstPlaceUserDto.FromDto());
        }


        if (leaderboard[1] != null)
        {
            var secondPlaceUserDto = leaderboard[1].WebUser;

            secondPlaceUserDto.AvailablePoints += secondPlaceReward;
            secondPlaceUserDto.AvailablePoints += CalculateRewardsForQuiz(secondPlaceUserDto);

            await WebUserDataAccess.UpdateWebUserAsync(secondPlaceUserDto.FromDto());
        }

        if (leaderboard[2] != null)
        {
            var thirdPlaceUserDto = leaderboard[2].WebUser;

            thirdPlaceUserDto.AvailablePoints += thirdPlaceReward;
            thirdPlaceUserDto.AvailablePoints += CalculateRewardsForQuiz(thirdPlaceUserDto);

            await WebUserDataAccess.UpdateWebUserAsync(thirdPlaceUserDto.FromDto());

        }

        if (leaderboard.Count > 3)
        {
            for (int i = 3; i < leaderboard.Count; i++)
            {
                var webUserDto = leaderboard[i].WebUser;
                webUserDto.AvailablePoints += participationReward;
                webUserDto.AvailablePoints += CalculateRewardsForQuiz(webUserDto);
                await WebUserDataAccess.UpdateWebUserAsync(webUserDto.FromDto());
            }

        }

    }

    public async Task DistributeQuizRewardsAsync(WebUserDto webUserDto)
    {
        webUserDto.AvailablePoints += CalculateRewardsForQuiz(webUserDto);
        await WebUserDataAccess.UpdateWebUserAsync(webUserDto.FromDto());
    }

    private int CalculateRewardsForQuiz(WebUserDto webUserDto)
    {
        if (webUserDto.NumberOfCorrectAnswers > 0)
        {
            int questionRewardValue = 8;
            return webUserDto.NumberOfCorrectAnswers * questionRewardValue;

        }
        else
        {
            return 0;

        }
    }

    public Task<IEnumerable<CurrentChallengeParticipant>> BuildLeaderboardFromParticipantList(IEnumerable<CurrentChallengeParticipant> currentChallengeEntries)
    {

        currentChallengeEntries.OrderByDescending(challengeRow => WebUserDataAccess.GetWebUserByIdAsync(challengeRow.FKWebUserId).Result.ToDto().NumberOfCorrectAnswers);
    }
}
