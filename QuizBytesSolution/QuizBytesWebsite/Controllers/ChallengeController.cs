using Microsoft.AspNetCore.Mvc;
using WebApiClient;

namespace QuizBytesWebsite.Controllers
{
    public class ChallengeController : Controller
    {
        public IChallengeFacadeApiClient ChallengeFacadeApiClient { get; set; }

        public ChallengeController(IChallengeFacadeApiClient client)
        {
            ChallengeFacadeApiClient = client;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register()
        {
            await ChallengeFacadeApiClient.RegisterParticipantAsync();
        }

        public IActionResult Start()
        {
            return View();
        }
    }
}
