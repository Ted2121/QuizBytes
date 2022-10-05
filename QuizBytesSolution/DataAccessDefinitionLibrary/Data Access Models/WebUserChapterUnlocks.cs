namespace DataAccessDefinitionLibrary.DAO_models
{
    public class WebUserChapterUnlocks
    {
        public string WebUserUsername { get; set; }
        public int ChapterId { get; set; }
        public WebUserModel WebUser { get; set; }
        public ChapterModel Chapter { get; set; }
    }
}
