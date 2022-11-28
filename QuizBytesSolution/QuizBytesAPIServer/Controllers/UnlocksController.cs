using DataAccessDefinitionLibrary.DAO_Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizBytesAPIServer.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UnlocksController : ControllerBase
{
    private IWebUserChapterUnlockDataAccess WebUserChapterUnlockDataAccess { get; set; }
    private IChapterDataAccess ChapterDataAccess { get; set; }
    private IWebUserDataAccess WebUserDataAccess { get; set; }

    public UnlocksController(IWebUserChapterUnlockDataAccess webUserChapterUnlockData, IChapterDataAccess chapterDataAccess, IWebUserDataAccess webUserDataAccess)
    {
        WebUserChapterUnlockDataAccess = webUserChapterUnlockData;
        ChapterDataAccess = chapterDataAccess;
        WebUserDataAccess = webUserDataAccess;
    }

    [HttpGet]
    [Route("webuser/{id}")]
    public async Task<ActionResult<IEnumerable<ChapterDto>>> GetUnlockedChaptersOfWebUserAsync(int id)
    {
        var user = await WebUserDataAccess.GetWebUserByIdAsync(id);
        var webUserUnlocks = await WebUserChapterUnlockDataAccess.GetAllWebUserChapterUnlocksByWebUserAsync(user);

        // We need to do this because in the DB we only store the Ids of the webusers and chapters in the WebUserChapterUnlock table
        // and we want to return the whole chapter object that matches the Id
        ICollection<ChapterDto> chapters = new List<ChapterDto>();

        foreach(var unlock in webUserUnlocks)
        {
            var chapter = await ChapterDataAccess.GetChapterByIdAsync(unlock.FKChapterId);
            chapters.Add(chapter.ToDto());
        }

        if(chapters == null)
        {
            return NotFound();
        }

        return Ok(chapters);
    }

    [HttpGet]
    [Route("chapter/{id}")]
    public async Task<ActionResult<IEnumerable<WebUserDto>>> GetAllWebUserChapterUnlocksByChapterAsync(int id)
    {
        var chapterFound = await ChapterDataAccess.GetChapterByIdAsync(id);
        var webUserUnlocks = await WebUserChapterUnlockDataAccess.GetAllWebUserChapterUnlocksByChapterAsync(chapterFound);

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
    public async Task<ActionResult<WebUserChapterUnlockDto>> UnlockChapterAsync(WebUserChapterUnlockDto webUserChapterUnlock)
    {
        int unlockPrice = 64;
        var webUserDto = webUserChapterUnlock.WebUserDto;
        if (webUserDto.AvailablePoints < unlockPrice)
        {
            return BadRequest();
        }
        if(await WebUserChapterUnlockDataAccess.InsertWebUserChapterUnlockAsync(webUserChapterUnlock.WebUserDto.Id, webUserChapterUnlock.ChapterDto.Id) == (0, 0))
        {
            return NotFound();
        }
        webUserDto.AvailablePoints -= unlockPrice;
        await WebUserDataAccess.UpdateWebUserAsync(webUserDto.FromDto());
        return Ok(webUserChapterUnlock);
    }

}
