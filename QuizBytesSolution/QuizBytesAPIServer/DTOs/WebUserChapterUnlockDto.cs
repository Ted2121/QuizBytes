using DataAccessDefinitionLibrary.Data_Access_Models;

namespace QuizBytesAPIServer.DTOs;

public class WebUserChapterUnlockDto
{
    public int WebUserId { get; set; }
    public int ChapterId { get; set; }
    public WebUser WebUserDto { get; set; }
    public Chapter ChapterDto { get; set; }

    // TODO add this as logic for unlocking the chapter
    // if(webUser.AvailablePoints >= chapter.UnlockPrice)
}
