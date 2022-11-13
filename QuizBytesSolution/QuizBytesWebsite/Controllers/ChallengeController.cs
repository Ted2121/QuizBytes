using Microsoft.AspNetCore.Mvc;

namespace QuizBytesWebsite.Controllers
{
    public class ChallengeController : Controller
    {
      //  public IQuizBytesApiClient _client { get; set; }

      /*  public ChallengeController(IQuizBytesApiClient client)
        {
            _client = client;
        }*/

        public ActionResult Register()
        {
            return View();
        }


    }
}
