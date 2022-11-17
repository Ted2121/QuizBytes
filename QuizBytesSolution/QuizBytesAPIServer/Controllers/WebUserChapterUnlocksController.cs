using DataAccessDefinitionLibrary.DAO_Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizBytesAPIServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WebUserChapterUnlocksController : ControllerBase
{
    private IWebUserChapterUnlockDataAccess WebUserChapterUnlockDataAccess { get; set; }
    private IChapterDataAccess ChapterDataAccess { get; set; }
    private IWebUserDataAccess WebUserDataAccess { get; set; }

    public WebUserChapterUnlocksController(IWebUserChapterUnlockDataAccess webUserChapterUnlockData, IChapterDataAccess chapterDataAccess, IWebUserDataAccess webUserDataAccess)
    {
        WebUserChapterUnlockDataAccess = webUserChapterUnlockData;
        ChapterDataAccess = chapterDataAccess;
        WebUserDataAccess = webUserDataAccess;
    }

    [HttpGet]
    [Route("webuser")]
    public async Task<ActionResult<IEnumerable<ChapterDto>>> GetUnlockedChaptersOfWebUserAsync(WebUserDto webUser)
    {
        var webUserUnlocks = await WebUserChapterUnlockDataAccess.GetAllWebUserChapterUnlocksByWebUserAsync(webUser.FromDto());

        // We need to do this because in the DB we only store the Ids of the webusers and chapters in the WebUserChapterUnlock table
        // and we want to return the whole chapter object that matches the Id
        ICollection<ChapterDto> chapters = new List<ChapterDto>();

        Parallel.ForEach(webUserUnlocks,
            async unlock =>
            {
                var chapter = await ChapterDataAccess.GetChapterByIdAsync(unlock.FKChapterId);
                chapters.Add(chapter.ToDto());
            });

        if(chapters == null)
        {
            return NotFound();
        }

        return Ok(chapters);
    }

    [HttpGet]
    [Route("chapter")]
    public async Task<ActionResult<IEnumerable<WebUserDto>>> GetAllWebUserChapterUnlocksByChapterAsync(ChapterDto chapter)
    {
        var webUserUnlocks = await WebUserChapterUnlockDataAccess.GetAllWebUserChapterUnlocksByChapterAsync(chapter.FromDto());

        ICollection<WebUserDto> webUsers = new List<WebUserDto>();

        Parallel.ForEach(webUserUnlocks,
            async unlock =>
            {
                var webUser = await WebUserDataAccess.GetWebUserByIdAsync(unlock.FKWebUserId);
                webUsers.Add(webUser.ToDto());
            });

        if (webUsers == null)
        {
            return NotFound();
        }

        return Ok(webUsers);

    }

    [HttpPost]
    [Route("unlock")]
    public async Task<ActionResult<WebUserChapterUnlockDto>> UnlockChapterAsync(WebUserChapterUnlockDto webUserChapterUnlock)
    {
        
        if(await WebUserChapterUnlockDataAccess.InsertWebUserChapterUnlockAsync(webUserChapterUnlock.WebUser.Id, webUserChapterUnlock.Chapter.Id) == (null, null))
        {
            return BadRequest();
        }
        return Ok(webUserChapterUnlock);
    }

}
