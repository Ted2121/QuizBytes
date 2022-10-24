namespace DataAccessDefinitionLibrary.DAO_models
{
    public class WebUserChapterUnlocks
    {
        public int WebUserId { get; set; }
        public int ChapterId { get; set; }
        public WebUser WebUser { get; set; }
        public Chapter Chapter { get; set; }

        public WebUserChapterUnlocks()
        {

        }
    }
}
