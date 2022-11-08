using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;
using SQLAccessImplementationLibrary;

namespace QuizBytesAPIServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ChallengeController : ControllerBase
    {
        public ICurrentChallengeParticipantDataAccess CurrentChallengeDataAccess { get; set; }
        public IWebUserDataAccess WebUserDataAccess { get; set; }

        public ChallengeController(
            ICurrentChallengeParticipantDataAccess currentChallengeDataAccess,
            IWebUserDataAccess webUserDataAccess)
        {
            CurrentChallengeDataAccess = currentChallengeDataAccess;
            WebUserDataAccess = webUserDataAccess;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrentChallengeDto>>> GetAllAsync()
        {
            var currentChallengeEntries = await CurrentChallengeDataAccess.GetAllRowsInChallengeAsync();

            currentChallengeEntries.OrderByDescending(challenge => WebUserDataAccess.GetWebUserByIdAsync(challenge.FKWebUserId).Result.AvailablePoints);

            if (currentChallengeEntries == null)
            {
                return NotFound();
            }
            return Ok(currentChallengeEntries.ToDtos());

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {

        }

    }
}

