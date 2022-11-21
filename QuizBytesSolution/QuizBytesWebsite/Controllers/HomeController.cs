using Microsoft.AspNetCore.Mvc;
using QuizBytesWebsite.Models;
using System.Diagnostics;

namespace QuizBytesWebsite.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

       
    }
}