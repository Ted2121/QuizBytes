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
        public ICurrentChallengeDataAccess CurrentChallengeDataAccess { get; set; }

        public ChallengeController(ICurrentChallengeDataAccess currentChallengeDataAccess)
        {
            CurrentChallengeDataAccess = currentChallengeDataAccess;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrentChallengeDto>>> GetAllAsync()
        {
            // TODO add ordering by points and handing out rewards
            var currentChallengeEntries = await CurrentChallengeDataAccess.GetAllRowsInChallengeAsync();

            if (currentChallengeEntries == null)
            {
                return NotFound();
            }
            return Ok(currentChallengeEntries.ToDtos());

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync()

    }
}

