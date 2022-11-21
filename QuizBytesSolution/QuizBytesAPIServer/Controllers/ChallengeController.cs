using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;
using QuizBytesAPIServer.Factories;
using QuizBytesAPIServer.Helper_Classes;
using SQLAccessImplementationLibrary;

namespace QuizBytesAPIServer.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ChallengeController : ControllerBase
{
    private ICurrentChallengeParticipantDataAccess CurrentChallengeParticipantDataAccess { get; set; }
    private IWebUserDataAccess WebUserDataAccess { get; set; }
    private IRewardsDistributionHelper RewardsDistributionHelper { get; set; }
    private IQuizFactory QuizFactory { get; set; }

    public ChallengeController(
        ICurrentChallengeParticipantDataAccess currentChallengeParticipantDataAccess,
        IWebUserDataAccess webUserDataAccess,
        IRewardsDistributionHelper rewardsDistributionHelper,
        IQuizFactory quizFactory)
    {
        CurrentChallengeParticipantDataAccess = currentChallengeParticipantDataAccess;
        WebUserDataAccess = webUserDataAccess;
        RewardsDistributionHelper = rewardsDistributionHelper;
        QuizFactory = quizFactory;
    }

    [HttpGet]
    [Route("participants")]
    public async Task<ActionResult<IEnumerable<CurrentChallengeParticipantDto>>> GetAllParticipantsAsync()
    {
        var currentChallengeEntries = await CurrentChallengeParticipantDataAccess.GetAllRowsInChallengeAsync();

        //var leaderboard = await RewardsDistributionHelper.BuildLeaderboardFromParticipantList(currentChallengeEntries.ToDtos());

        if (currentChallengeEntries == null)
        {
            return NotFound();
        }
        return Ok(currentChallengeEntries.ToDtos());


    }

    [HttpDelete]
    [Route("participants/{id}")]
    public async Task<ActionResult> DeregisterParticipantAsync([FromQuery]int id)
    {
        if (!await CurrentChallengeParticipantDataAccess.DeleteWebUserFromChallengeAsync(id))
        { return NotFound(); }
        else
        { return Ok(); }
    }

    [HttpPut]
    [Route("rewards")]
    public async Task<ActionResult> DistributeRewardsAsync(IEnumerable<CurrentChallengeParticipantDto> leaderboard)
    {
        //var leaderboardResult = await GetAllParticipantsAsync();
        //var leaderboard = leaderboardResult.Value?.ToList();
        
        if(leaderboard == null)
        {
            return NotFound();
        }

        await RewardsDistributionHelper.DistributeChallengeRewardsAsync(leaderboard.ToList());

        return Ok();

    }

    [HttpDelete]
    [Route("cleartable")]
    public async Task<ActionResult> ClearTempTableBeforeNextChallengeAsync()
    {
        
        if(!await CurrentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync())
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<int>> RegisterParticipantAsync(ChallengeParticipantInfoDto challengeParticipantInfo)
    {
        if(challengeParticipantInfo == null)
        {
            return NotFound();
        }
        
        return Ok(await CurrentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(challengeParticipantInfo.WebUser.FromDto(), challengeParticipantInfo.Course.FromDto()));
    }

    [HttpGet]
    [Route("count")]
    public async Task<ActionResult<int>> GetNumberOfParticipantsAsync()
    {
        var numberOfParticipants = await CurrentChallengeParticipantDataAccess.GetRowAmountFromDatabaseAsync();
        return Ok(numberOfParticipants);
    }

    [HttpGet]
    [Route("quiz")]
    public async Task<ActionResult<QuizDto>> GetChallengeQuizAsync(CourseDto course)
    {
        var quiz = await QuizFactory.CreateQuizDto(course);

        return Ok(quiz);
    }

    [HttpGet]
    [Route("query-participation/{id}")]
    public async Task<ActionResult<bool>> CheckIfUserIsInChallengeAsync([FromQuery]int id)
    {
        var result = await CurrentChallengeParticipantDataAccess.CheckIfWebUserIsInChallengeAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok(result);
    }
}

