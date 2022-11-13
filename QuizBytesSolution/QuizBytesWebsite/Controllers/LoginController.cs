using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuizBytesWebsite.Controllers
{
    public class LoginController : Controller
    {
        // GET: HomeController1
        public ActionResult Login()
        {
            return View();
        }
    }
}
