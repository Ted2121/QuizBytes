using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizBytesWebsite.Helpers;
using QuizBytesWebsite.Models;
using WebApiClient.DTOs;

namespace QuizBytesWebsite.Controllers;

[Authorize]
public class LeaderboardController : Controller
{
    public ILeaderboardBuilder LeaderboardBuilder { get; set; }
    public LeaderboardController(ILeaderboardBuilder leaderboardBuilder)
    {
        LeaderboardBuilder = leaderboardBuilder;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Display()
    {
        var leaderboard = LeaderboardBuilder.BuildLeaderboardFromParticipantList();
        LeaderboardModel leaderboardModel = new LeaderboardModel();
          leaderboardModel.Leaderboard  = FilterUserProperties(leaderboard);
        return View(leaderboardModel);
    }

    private List<LeaderboardInfo> FilterUserProperties(LeaderboardDto leaderboard)
    {
        var leaderboardWithFilteredProperties = new List<LeaderboardInfo>();
        var users = leaderboard.Leaderboard;

        if (users.Any())
        {
            for (int i = 0; i < users.Count; i++)
            {
                var leaderboardInfo = new LeaderboardInfo()
                {
                    Username = users[i].Username,
                    Points = CalculateUserPoints(users[i].CorrectAnswers),
                    ElapsedTime = ElapsedSecondsToString(users[i].ElapsedSecondsInChallenge)
                };

                leaderboardWithFilteredProperties.Add(leaderboardInfo);
            }
        }
        return leaderboardWithFilteredProperties;
    }

    private int CalculateUserPoints(int numberOfCorrectAnswers) => numberOfCorrectAnswers * 8;
    private string ElapsedSecondsToString(int elapsedSeconds)
    {
        var timespan = TimeSpan.FromSeconds(elapsedSeconds);
        return timespan.ToString(@"hh\:mm\:ss");
    }

}




