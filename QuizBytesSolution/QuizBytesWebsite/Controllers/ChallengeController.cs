using Microsoft.AspNetCore.Mvc;
using QuizBytesWebsite.Helpers;
using WebApiClient;
using WebApiClient.DTOs;

namespace QuizBytesWebsite.Controllers
{
    public class ChallengeController : Controller
    {
        private IWebUserFacadeApiClient WebUserFacadeApiClient { get; set; }
        private IChallengeFacadeApiClient ChallengeFacadeApiClient { get; set; }
        private ICourseSelectionHelper CourseSelectionHelper { get; set; }


        public ChallengeController(IChallengeFacadeApiClient client, ICourseSelectionHelper courseSelectionHelper, IWebUserFacadeApiClient webUserFacadeApiClient)
        {
            ChallengeFacadeApiClient = client;
            CourseSelectionHelper = courseSelectionHelper;
            WebUserFacadeApiClient = webUserFacadeApiClient;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser()
        {
            // example of id from claim:@Context.User.Claims.FirstOrDefault((claim)=> claim.Type == "id")?.Value
            var userToRegister = await GetUserFromClaim();
            await ChallengeFacadeApiClient.RegisterParticipantAsync(userToRegister, await CourseSelectionHelper.GetCourseForChallenge());
            return RedirectToAction("Start", "Challenge");
        }

        private async Task<WebUserDto> GetUserFromClaim()
        {
            var stringIdOfUserToRegister = HttpContext.User.Claims.FirstOrDefault((claim) => claim.Type == "id")?.Value;
            int userId;
            bool success = int.TryParse(stringIdOfUserToRegister, out userId);

            if (success)
            {
                return await WebUserFacadeApiClient.GetWebUserByIdAsync(userId);
            }
            else
            {
                return null;
            }
        }

        public IActionResult Start()
        {
            return View();
        }
    }
}
