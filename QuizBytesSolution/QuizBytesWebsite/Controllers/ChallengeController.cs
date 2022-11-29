﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizBytesWebsite.Helpers;
using WebApiClient;
using WebApiClient.DTOs;

namespace QuizBytesWebsite.Controllers;

[Authorize]
public class ChallengeController : Controller
{
    private IWebUserFacadeApiClient WebUserFacadeApiClient { get; set; }
    private IChallengeFacadeApiClient ChallengeFacadeApiClient { get; set; }
    private ICourseSelectionHelper CourseSelectionHelper { get; set; }
    private ILeaderboardBuilder LeaderboardBuilder { get; set; }


    public ChallengeController(IChallengeFacadeApiClient client, ICourseSelectionHelper courseSelectionHelper, IWebUserFacadeApiClient webUserFacadeApiClient, ILeaderboardBuilder leaderboardBuilder)
    {
        ChallengeFacadeApiClient = client;
        CourseSelectionHelper = courseSelectionHelper;
        WebUserFacadeApiClient = webUserFacadeApiClient;
        LeaderboardBuilder = leaderboardBuilder;
    }

    #region Registration
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Refuse()
    {
        return View();
    }
    #endregion

    #region Start

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Start(int id)
    {
        if (LeaderboardBuilder.Participants == null)
        {
            LeaderboardBuilder.InitializeChallenge();
        }

        var userToRegister = await GetUserFromClaimAsync();
        //var courseForChallenge = await CourseSelectionHelper.GetCourseForChallenge();
        if (await ChallengeFacadeApiClient.CheckIfUserIsInChallengeAsync(userToRegister.Id))
        {
            return RedirectToAction("Refuse");
        }

        // We use monday for the presentation because we only inserted data into the DB for the monday course
        var courseForChallenge = await CourseSelectionHelper.GetCourseForChallenge("monday");

        await ChallengeFacadeApiClient.RegisterParticipantAsync(userToRegister, courseForChallenge);
        //TODO needs to be moved to when the user finishes the challenge (right after getting the number of correct answers and elapsed time as json)
       

        return RedirectToAction("Start");
    }
    public IActionResult Start()
    {
        return View();
    }

    private async Task<WebUserDto> GetUserFromClaimAsync()
    {
        var stringIdOfUserToRegister = HttpContext.User.Claims.FirstOrDefault((claim) => claim.Type == "id")?.Value;
        int userId;
        bool success = int.TryParse(stringIdOfUserToRegister, out userId);

        if (success)
        {
            return await WebUserFacadeApiClient.GetWebUserByIdAsync(userId);
        }
        else
        {
            return null;
        }
    }

    #endregion

    #region Quiz

    [AllowAnonymous]
    [HttpGet]
    [Route("Challenge/Quiz/efHFkfd923md03zz0dfj")]
    public async Task<JsonResult> Quiz()
    {
        //var courseForChallenge = await CourseSelectionHelper.GetCourseForChallenge();
        var courseForChallenge = await CourseSelectionHelper.GetCourseForChallenge("monday");
        var quiz = await GetQuiz(courseForChallenge);
        return Json(quiz);
    }
    private async Task<QuizDto> GetQuiz(CourseDto courseForChallenge)
    {
        return await ChallengeFacadeApiClient.GetChallengeQuizAsync(courseForChallenge);
    }
    #endregion

    #region Finish
    [AllowAnonymous]
    [HttpPost]
<<<<<<< HEAD
    public async Task UpdateUser(WebUserChallengeInfoDto userInfo)
=======
    public async Task<IActionResult> UpdateUser(WebUserChallengeInfoDto userInfo)
>>>>>>> 29db193d1b1f5544a74311a7f4dc01cea0f89977
    {
        var user = await GetUserFromClaimAsync();
        user.NumberOfCorrectAnswers = userInfo.CorrectAnswers;
        user.ElapsedSecondsInChallenge = userInfo.ElapsedTime;
        await WebUserFacadeApiClient.UpdateWebUserAsync(user);

        return Ok();
    }

    [HttpPost]
    public async Task Finish(int id)
    {
        var courseForChallenge = await CourseSelectionHelper.GetCourseForChallenge("monday");
        var userToRegister = await GetUserFromClaimAsync();

        LeaderboardBuilder.AddParticipantToLeaderboard(new CurrentChallengeParticipantDto()
        {
            WebUser = userToRegister,
            Course = courseForChallenge
        });
    }

    [HttpGet]
    public IActionResult Finish()
    {
        // The leaderboard itself is created in js
        return RedirectToAction("Display", "Leaderboard");
    }
    
    #endregion

}