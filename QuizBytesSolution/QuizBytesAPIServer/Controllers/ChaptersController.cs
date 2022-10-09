using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.Models;
using System.Security.Principal;

namespace QuizBytesAPIServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ChaptersController : ControllerBase
    {
        public IChapterDataAccess ChapterDataAccess { get; set; }

        public ChaptersController(IChapterDataAccess chapterDataAccess)
        {
            ChapterDataAccess = chapterDataAccess;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteChapterAsync(Chapter chapter)
        {
            if (chapter == null)
            {
                return NotFound();
            }

            await ChapterDataAccess.DeleteChapterAsync(chapter);
            // TODO figure out how to check if deletion was successfull

            return Ok(); 
        }


        [HttpGet]
        [Route("{all}")]
        public async Task<ActionResult<IEnumerable<Chapter>>> GetAllChaptersAsync()
        {
            var chapters = await ChapterDataAccess.GetAllChaptersAsync();

            if (chapters == null)
            {
                return NotFound();
            }
            return Ok(chapters);
        }

        [HttpGet]
        [Route("subject")]
        public async Task<ActionResult<IEnumerable<Chapter>>> GetAllChaptersBySubjectAsync(Subject subject)
        {
            var chapters = await ChapterDataAccess.GetAllChaptersBySubjectAsync(subject);

            if (chapters == null)
            {
                return NotFound();
            }
            return Ok(chapters); 
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Chapter>> GetChapterByIdAsync(int chapterId)
        {
            Chapter chapter = await ChapterDataAccess.GetChapterByIdAsync(chapterId);
            if (chapter == null)
            {
                return NotFound();
            }
            return Ok(chapter); 
        }

        [HttpPost]
        public async Task<ActionResult<Chapter>> InsertChapterAsync(Chapter chapter)
        {
            chapter = await ChapterDataAccess.InsertChapterAsync(chapter);

            if (chapter == null)
            {
                return NotFound();
            }
            return Ok(chapter); 
        } 


        [HttpPut]
        public async Task<ActionResult> UpdateChapterAsync(Chapter chapter)
        {

            if (chapter == null)
            {
                return NotFound();
            }

            await ChapterDataAccess.UpdateChapterAsync(chapter);

            return Ok();

        }
    }
}