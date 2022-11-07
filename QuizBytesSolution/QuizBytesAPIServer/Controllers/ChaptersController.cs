using DataAccessDefinitionLibrary.DAO_Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;


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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChapterDto>>> GetAllChaptersAsync()
        {
            var chapters = await ChapterDataAccess.GetAllChaptersAsync();

            if (chapters == null)
            {
                return NotFound();
            }
            return Ok(chapters.ToDtos());
        }

        [HttpGet]
        [Route("subject")]
        public async Task<ActionResult<IEnumerable<ChapterDto>>> GetAllChaptersBySubjectAsync([FromQuery] SubjectDto subject)
        {
            var chapters = await ChapterDataAccess.GetAllChaptersBySubjectAsync(subject.FromDto());

            if (chapters == null)
            {
                return NotFound();
            }
            return Ok(chapters.ToDtos());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ChapterDto>> GetChapterByIdAsync([FromQuery] int chapterId)
        {
            var chapter = await ChapterDataAccess.GetChapterByIdAsync(chapterId);
            if (chapter == null)
            {
                return NotFound();
            }
            return Ok(chapter.ToDto());
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteChapterAsync([FromBody] ChapterDto chapter)
        {
            if (chapter == null)
            {
                return NotFound();
            }

            await ChapterDataAccess.DeleteChapterAsync(chapter.FromDto());

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<ChapterDto>> InsertChapterAsync([FromBody] ChapterDto chapter)
        {
            if (chapter == null)
            {
                return NotFound();
            }
            await ChapterDataAccess.InsertChapterAsync(chapter.FromDto());
            return Ok(chapter);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateChapterAsync([FromBody] ChapterDto chapter)
        {

            if (chapter == null)
            {
                return NotFound();
            }

            await ChapterDataAccess.UpdateChapterAsync(chapter.FromDto());

            return Ok();

        }
    }
}