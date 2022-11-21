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

    public async Task DistributeChallengeRewardsAsync(List<WebUserDto> leaderboard)
    {
        int firstPlaceReward = 256;
        int secondPlaceReward = 128;
        int thirdPlaceReward = 64;
        int participationReward = 32;

        if (leaderboard[0] != null)
        {

            var firstPlaceUserDto = leaderboard[0];

            int quizPointsToAdd = CalculateRewardsForQuiz(firstPlaceUserDto);
            int rankPointsToAdd = firstPlaceReward;
            int totalPointsToAdd = quizPointsToAdd + rankPointsToAdd;
            firstPlaceUserDto.AvailablePoints += totalPointsToAdd;
            firstPlaceUserDto.TotalPoints += totalPointsToAdd;

            await WebUserDataAccess.UpdateWebUserAsync(firstPlaceUserDto.FromDto());
        }


        if (leaderboard[1] != null)
        {
            var secondPlaceUserDto = leaderboard[1];

            int quizPointsToAdd = CalculateRewardsForQuiz(secondPlaceUserDto);
            int rankPointsToAdd = secondPlaceReward;
            int totalPointsToAdd = quizPointsToAdd + rankPointsToAdd;
            secondPlaceUserDto.AvailablePoints += totalPointsToAdd;
            secondPlaceUserDto.TotalPoints += totalPointsToAdd;

            await WebUserDataAccess.UpdateWebUserAsync(secondPlaceUserDto.FromDto());
        }

        if (leaderboard[2] != null)
        {
            var thirdPlaceUserDto = leaderboard[2];

            int quizPointsToAdd = CalculateRewardsForQuiz(thirdPlaceUserDto);
            int rankPointsToAdd = thirdPlaceReward;
            int totalPointsToAdd = quizPointsToAdd + rankPointsToAdd;
            thirdPlaceUserDto.AvailablePoints += totalPointsToAdd;
            thirdPlaceUserDto.TotalPoints += totalPointsToAdd;

            await WebUserDataAccess.UpdateWebUserAsync(thirdPlaceUserDto.FromDto());

        }

        if (leaderboard.Count > 3)
        {
            for (int i = 3; i < leaderboard.Count; i++)
            {
                var webUserDto = leaderboard[i];
                int quizPointsToAdd = CalculateRewardsForQuiz(webUserDto);
                int rankPointsToAdd = participationReward;
                int totalPointsToAdd = quizPointsToAdd + rankPointsToAdd;
                webUserDto.AvailablePoints += totalPointsToAdd;
                webUserDto.TotalPoints += totalPointsToAdd;

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

   
}
