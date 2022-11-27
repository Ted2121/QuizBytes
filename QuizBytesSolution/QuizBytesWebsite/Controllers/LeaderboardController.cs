using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuizBytesWebsite.Controllers
{
    [Authorize]
    public class LeaderboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Display()
        {
            return View();
        }
    }
}
