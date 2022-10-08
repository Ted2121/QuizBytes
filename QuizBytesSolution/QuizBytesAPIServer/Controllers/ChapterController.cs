using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.Models;
using System.Security.Principal;

namespace QuizBytesAPIServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ChapterController : ControllerBase
    {
        public IChapterDataAccess ChapterDataAccess { get; set; }

        public ChapterController(IChapterDataAccess chapterDataAccess)
        {
            ChapterDataAccess = chapterDataAccess;
        }

        [HttpGet]
        [Route("{all}")]
        public ActionResult<IEnumerable<Chapter>> GetAllChapters()
        {
            return Ok(ChapterDataAccess.GetAllChapters());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Chapter> GetChapterById(int chapterId)
        {
            Chapter chapter = ChapterDataAccess.GetChapterById(chapterId);
            if (chapter == null)
            {
                return NotFound();
            }
            return Ok(chapter); 
        }
    }
}