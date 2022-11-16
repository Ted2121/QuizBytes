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

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Start()
        {
            return View();
        }
    }
}
