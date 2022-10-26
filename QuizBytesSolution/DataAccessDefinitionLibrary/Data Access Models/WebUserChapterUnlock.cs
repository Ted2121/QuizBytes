namespace DataAccessDefinitionLibrary.Data_Access_Models
{
    public class WebUserChapterUnlock
    {
        public int WebUserId { get; set; }
        public int ChapterId { get; set; }
        public WebUser WebUser { get; set; }
        public Chapter Chapter { get; set; }

        public WebUserChapterUnlock()
        {

        }
    }
}
