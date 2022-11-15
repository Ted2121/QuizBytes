using DataAccessDefinitionLibrary.DAO_Interfaces;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;

namespace QuizBytesAPIServer.Helper_Classes
{
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

            var firstPlaceUserDto = leaderboard[0].WebUser;
            var secondPlaceUserDto = leaderboard[1].WebUser;
            var thirdPlaceUserDto = leaderboard[2].WebUser;

           
            firstPlaceUserDto.AvailablePoints += firstPlaceReward;
            firstPlaceUserDto.AvailablePoints += CalculateRewardsForQuiz(firstPlaceUserDto);

            secondPlaceUserDto.AvailablePoints += secondPlaceReward;
            secondPlaceUserDto.AvailablePoints += CalculateRewardsForQuiz(secondPlaceUserDto);

            thirdPlaceUserDto.AvailablePoints += thirdPlaceReward;
            thirdPlaceUserDto.AvailablePoints += CalculateRewardsForQuiz(thirdPlaceUserDto);

            await WebUserDataAccess.UpdateWebUserAsync(firstPlaceUserDto.FromDto());
            await WebUserDataAccess.UpdateWebUserAsync(secondPlaceUserDto.FromDto());
            await WebUserDataAccess.UpdateWebUserAsync(thirdPlaceUserDto.FromDto());

            for(int i = 3; i < leaderboard.Count; i++)
            {
                var webUserDto = leaderboard[i].WebUser;
                webUserDto.AvailablePoints += participationReward;
                webUserDto.AvailablePoints += CalculateRewardsForQuiz(webUserDto);
                await WebUserDataAccess.UpdateWebUserAsync(webUserDto.FromDto());
            }

        }

        public async Task DistributeQuizRewardsAsync(WebUserDto webUserDto)
        {
            webUserDto.AvailablePoints += CalculateRewardsForQuiz(webUserDto);
            await WebUserDataAccess.UpdateWebUserAsync(webUserDto.FromDto());
        }

        private int CalculateRewardsForQuiz(WebUserDto webUserDto)
        {
            int questionRewardValue = 8;
            return webUserDto.NumberOfCorrectAnswers * questionRewardValue;
        }
    }
}
