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

    public async Task DistributeChallengeRewardsAsync(LeaderboardDto leaderboard)
    {
        int firstPlaceReward = 256;
        int secondPlaceReward = 128;
        int thirdPlaceReward = 64;
        int participationReward = 32;

        for(int i = 0; i < leaderboard.Leaderboard.Count; i++)
        {
            switch (i)
            {
            case 0:
                {
                    int quizPointsToAdd = CalculateRewardsForQuiz(leaderboard.Leaderboard[i]);
                    int rankPointsToAdd = firstPlaceReward;
                    int totalPointsToAdd = quizPointsToAdd + rankPointsToAdd;
                    leaderboard.Leaderboard[i].AvailablePoints += totalPointsToAdd;
                    leaderboard.Leaderboard[i].TotalPoints += totalPointsToAdd;

                    await WebUserDataAccess.UpdateWebUserAsync(leaderboard.Leaderboard[i].FromDto());
                }
                break;
                case 1:
                {
                    int quizPointsToAdd = CalculateRewardsForQuiz(leaderboard.Leaderboard[i]);
                    int rankPointsToAdd = secondPlaceReward;
                    int totalPointsToAdd = quizPointsToAdd + rankPointsToAdd;
                    leaderboard.Leaderboard[i].AvailablePoints += totalPointsToAdd;
                    leaderboard.Leaderboard[i].TotalPoints += totalPointsToAdd;

                    await WebUserDataAccess.UpdateWebUserAsync(leaderboard.Leaderboard[i].FromDto());
                }
                break;
                case 2:
                {

                    int quizPointsToAdd = CalculateRewardsForQuiz(leaderboard.Leaderboard[i]);
                    int rankPointsToAdd = thirdPlaceReward;
                    int totalPointsToAdd = quizPointsToAdd + rankPointsToAdd;
                    leaderboard.Leaderboard[i].AvailablePoints += totalPointsToAdd;
                    leaderboard.Leaderboard[i].TotalPoints += totalPointsToAdd;

                    await WebUserDataAccess.UpdateWebUserAsync(leaderboard.Leaderboard[i].FromDto());
                }
                break;
                default:
                {
                    int quizPointsToAdd = CalculateRewardsForQuiz(leaderboard.Leaderboard[i]);
                    int rankPointsToAdd = participationReward;
                    int totalPointsToAdd = quizPointsToAdd + rankPointsToAdd;
                    leaderboard.Leaderboard[i].AvailablePoints += totalPointsToAdd;
                    leaderboard.Leaderboard[i].TotalPoints += totalPointsToAdd;

                    await WebUserDataAccess.UpdateWebUserAsync(leaderboard.Leaderboard[i].FromDto());
                }
                break;
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
        if (webUserDto.CorrectAnswers > 0)
        {
            int questionRewardValue = 8;
            return webUserDto.CorrectAnswers * questionRewardValue;

        }
        else
        {
            return 0;
        }
    }
   
}
