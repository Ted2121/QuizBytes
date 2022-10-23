using Microsoft.AspNetCore.Mvc;
using ChapterDto = QuizBytesAPIServer.DTOs.ChapterDto;
using IChapterDataAccess = DataAccessDefinitionLibrary.DAO_Interfaces.IChapterDataAccess;
using SubjectDto = QuizBytesAPIServer.DTOs.SubjectDto;

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
        public async Task<ActionResult> DeleteChapterAsync(ChapterDto chapter)
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
        public async Task<ActionResult<IEnumerable<ChapterDto>>> GetAllChaptersAsync()
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
        public async Task<ActionResult<IEnumerable<ChapterDto>>> GetAllChaptersBySubjectAsync(SubjectDto subject)
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
        public async Task<ActionResult<ChapterDto>> GetChapterByIdAsync(int chapterId)
        {
            ChapterDto chapter = await ChapterDataAccess.GetChapterByIdAsync(chapterId);
            if (chapter == null)
            {
                return NotFound();
            }
            return Ok(chapter);
        }

        [HttpPost]
        public async Task<ActionResult<ChapterDto>> InsertChapterAsync(ChapterDto chapter)
        {
            chapter = await ChapterDataAccess.InsertChapterAsync(chapter);

            if (chapter == null)
            {
                return NotFound();
            }
            return Ok(chapter);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateChapterAsync(ChapterDto chapter)
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