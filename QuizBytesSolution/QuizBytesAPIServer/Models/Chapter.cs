namespace QuizBytesAPIServer.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FKSubjectId { get; set; }
        public Subject Subject { get; set; }
        public IEnumerable<WebUserChapterUnlocks> WebUserChapterUnlocks { get; set; }
    }
}
