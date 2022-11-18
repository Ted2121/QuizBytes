using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;


namespace QuizBytesAPIServer.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ChaptersController : ControllerBase
{
    private IChapterDataAccess ChapterDataAccess { get; set; }

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
    public async Task<ActionResult<IEnumerable<ChapterDto>>> GetAllChaptersBySubjectAsync([FromBody] SubjectDto subject)
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
    public async Task<ActionResult<ChapterDto>> GetChapterByIdAsync([FromQuery] int id)
    {
        var chapter = await ChapterDataAccess.GetChapterByIdAsync(id);
        if (chapter == null)
        {
            return NotFound();
        }
        return Ok(chapter.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteChapterAsync([FromQuery] int id)
    {
        if (!await ChapterDataAccess.DeleteChapterAsync(id))
        { return NotFound(); }
        else
        { return Ok(); }
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

        if (chapter == null || !await ChapterDataAccess.UpdateChapterAsync(chapter.FromDto()))
        {
            return NotFound();
        }

        return Ok();


    }
}