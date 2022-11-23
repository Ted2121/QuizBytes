using Microsoft.AspNetCore.Mvc;
using WebApiClient;

namespace QuizBytesWebsite.Controllers
{
    public class ChallengeController : Controller
    {
        //public IChallengeFacadeApiClient Client { get; set; }

        //public ChallengeController(IChallengeFacadeApiClient client)
        //{
        //    Client = client;
        //}

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Start()
        {
            return View();
        }
    }
}
