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
    private ICourseDataAccess CourseDataAccess { get; set; }

    public ChallengeController(
        ICurrentChallengeParticipantDataAccess currentChallengeParticipantDataAccess,
        IWebUserDataAccess webUserDataAccess,
        IRewardsDistributionHelper rewardsDistributionHelper,
        IQuizFactory quizFactory,
        ICourseDataAccess courseDataAccess)
    {
        CurrentChallengeParticipantDataAccess = currentChallengeParticipantDataAccess;
        WebUserDataAccess = webUserDataAccess;
        RewardsDistributionHelper = rewardsDistributionHelper;
        QuizFactory = quizFactory;
        CourseDataAccess = courseDataAccess;
    }

    [HttpGet]
    [Route("participants")]
    public async Task<ActionResult<IEnumerable<CurrentChallengeParticipantDto>>> GetAllParticipantsAsync()
    {
        var currentChallengeEntries = await CurrentChallengeParticipantDataAccess.GetAllRowsInChallengeAsync();

        if (currentChallengeEntries == null)
        {
            return NotFound();
        }
        return Ok(currentChallengeEntries.ToDtos());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeregisterParticipantAsync(int id)
    {
        if (!await CurrentChallengeParticipantDataAccess.DeleteWebUserFromChallengeAsync(id))
        { return NotFound(); }
        else
        { return Ok(); }
    }

    [HttpPut]
    [Route("rewards")]
    public async Task<ActionResult> DistributeRewardsAsync([FromBody] LeaderboardDto leaderboard)
    {
        
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
    public async Task<ActionResult<int>> RegisterParticipantAsync(CurrentChallengeParticipantDto challengeParticipantInfo)
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
    [Route("quiz/{id}")]
    public async Task<ActionResult<QuizDto>> GetChallengeQuizAsync(int id)
    {
        var course = await CourseDataAccess.GetCourseByIdAsync(id);
        var quiz = await QuizFactory.CreateQuizDto(course.ToDto());

        return Ok(quiz);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<bool>> CheckIfUserIsInChallengeAsync(int id)
    {
        var result = await CurrentChallengeParticipantDataAccess.CheckIfWebUserIsInChallengeAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok(result);
    }
}

