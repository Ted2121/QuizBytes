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
    public ICurrentChallengeParticipantDataAccess CurrentChallengeParticipantDataAccess { get; set; }
    public IWebUserDataAccess WebUserDataAccess { get; set; }
    public IRewardsDistributionHelper RewardsDistributionHelper { get; set; }
    public IQuizFactory QuizFactory { get; set; }

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

        currentChallengeEntries.OrderByDescending(challengeRow => WebUserDataAccess.GetWebUserByIdAsync(challengeRow.FKWebUserId).Result.AvailablePoints);

        if (currentChallengeEntries == null)
        {
            return NotFound();
        }
        return Ok(currentChallengeEntries.ToDtos());


    }

    [HttpDelete]
    [Route("participants/{id}")]
    public async Task<ActionResult> DeregisterParticipantAsync(int id)
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

        await RewardsDistributionHelper.DistributeChallengeRewardsAsync(leaderboard);

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
    public async Task<ActionResult<int>> RegisterParticipantAsync([FromBody]WebUserDto webUser, [FromQuery] CourseDto course)
    {
        if(webUser == null || course == null)
        {
            return NotFound();
        }
        
        return Ok(await CurrentChallengeParticipantDataAccess.AddWebUserToChallengeAsync(webUser.FromDto(), course.FromDto()));
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
    [Route("query-participation")]
    public async Task<ActionResult<bool>> CheckIfUserIsInChallengeAsync(int webUserId)
    {
        var result = await CurrentChallengeParticipantDataAccess.CheckIfWebUserIsInChallengeAsync(webUserId);
        if (!result)
        {
            return NotFound();
        }
        return Ok(result);
    }
}

