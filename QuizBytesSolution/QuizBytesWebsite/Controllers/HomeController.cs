using Microsoft.AspNetCore.Mvc;
using QuizBytesWebsite.Models;
using System.Diagnostics;

namespace QuizBytesWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //public IActionResult Quiz()
        //{
        //    return View();
        //}

        //public IActionResult Leaderboard()
        //{
        //    return View();
        //}

        //public IActionResult Login()
        //{
        //    return View();
        //}
        ///*public IActionResult Challenge()
        //{
        //    return View();
        //}*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}