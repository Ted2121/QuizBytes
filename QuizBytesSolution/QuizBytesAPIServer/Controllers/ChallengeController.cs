using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;
using QuizBytesAPIServer.Helper_Classes;
using SQLAccessImplementationLibrary;

namespace QuizBytesAPIServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ChallengeController : ControllerBase
    {
        public ICurrentChallengeParticipantDataAccess CurrentChallengeParticipantDataAccess { get; set; }
        public IWebUserDataAccess WebUserDataAccess { get; set; }
        public IRewardsDistributionHelper RewardsDistributionHelper { get; set; }

        public ChallengeController(
            ICurrentChallengeParticipantDataAccess currentChallengeParticipantDataAccess,
            IWebUserDataAccess webUserDataAccess,
            IRewardsDistributionHelper rewardsDistributionHelper)
        {
            CurrentChallengeParticipantDataAccess = currentChallengeParticipantDataAccess;
            WebUserDataAccess = webUserDataAccess;
            RewardsDistributionHelper = rewardsDistributionHelper;
        }

        [HttpGet]
        [Route("participants")]
        public async Task<ActionResult<IEnumerable<CurrentChallengeParticipantDto>>> GetAllParticipantsAsync()
        {
            var currentChallengeEntries = await CurrentChallengeParticipantDataAccess.GetAllRowsInChallengeAsync();

            currentChallengeEntries.OrderByDescending(challengeRow => WebUserDataAccess.GetWebUserByIdAsync(challengeRow.FKWebUserId).Result.AvailablePoints);

            if (currentChallengeEntries == null)
            {
                return NotFound();
            }
            return Ok(currentChallengeEntries.ToDtos());

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> DeleteParticipantAsync(int id)
        {
            if (!await CurrentChallengeParticipantDataAccess.DeleteWebUserFromChallengeAsync(id))
            { return NotFound(); }
            else
            { return Ok(); }
        }

        [HttpPut]
        [Route("rewards")]
        public async Task<ActionResult> DistributeRewardsAsync()
        {
            var leaderboardResult = await GetAllParticipantsAsync();
            var leaderboard = leaderboardResult.Value?.ToList();
            
            if(leaderboard == null)
            {
                return NotFound();
            }

            await RewardsDistributionHelper.DistributeChallengeRewards(leaderboard);

            return Ok();

        }


        public async Task<ActionResult> ClearTempTableBeforeNextChallengeAsync()
        {
            // TODO add a check in DAL for the count of rows to make sure this is empty after the method is called
            await CurrentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();
            return Ok();
        }



    }
}

