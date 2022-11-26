using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using WebApiClient;

namespace QuizBytesWebsite.Controllers
{
    public class QuizController : Controller
    {
        private ICourseFacadeApiClient CourseFacadeApiClient { get; set; }
        public QuizController(ICourseFacadeApiClient courseFacadeApiClient)
        {
            CourseFacadeApiClient = courseFacadeApiClient;
        }
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
        [HttpGet]
        public async Task<JsonResult> GetCourses()
        {
            return Json(await CourseFacadeApiClient.GetAllCoursesAsync());
        }
    }
}