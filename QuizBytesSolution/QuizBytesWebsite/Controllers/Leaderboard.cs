using Microsoft.AspNetCore.Mvc;

namespace QuizBytesWebsite.Controllers
{
    public class Leaderboard : Controller
    {
        public IActionResult Display()
        {
            return View("Leaderboard");
        }
    }
}
