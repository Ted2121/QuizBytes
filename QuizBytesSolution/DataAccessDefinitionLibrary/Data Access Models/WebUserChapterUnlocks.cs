namespace DataAccessDefinitionLibrary.DAO_models
{
    public class WebUserChapterUnlocks
    {
        public string WebUserUsername { get; set; }
        public int ChapterId { get; set; }
        public WebUser WebUser { get; set; }
        public Chapter Chapter { get; set; }

        public WebUserChapterUnlocks()
        {

        }
    }
}
