using Microsoft.AspNetCore.Mvc;

namespace QuizBytesWebsite.Controllers
{
    public class LeaderboardController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }
    }
}
