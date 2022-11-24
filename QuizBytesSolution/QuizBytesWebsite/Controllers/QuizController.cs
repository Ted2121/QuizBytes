using Microsoft.AspNetCore.Mvc;

namespace QuizBytesWebsite.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Start()
        {
            return View();
        }
        public IActionResult QuizCourses()
        {
            return View();
        }
        public IActionResult Quiz()
        {
            return View();
        }
    }
}
