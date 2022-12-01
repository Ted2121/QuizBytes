namespace DataAccessDefinitionLibrary.Data_Access_Models;

public class WebUserChapterUnlock
{
    public int FKWebUserId { get; set; }
    public int FKChapterId { get; set; }

    public WebUserChapterUnlock()
    {

    }
}
