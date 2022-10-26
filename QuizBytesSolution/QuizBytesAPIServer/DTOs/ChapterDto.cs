namespace QuizBytesAPIServer.DTOs
{
    public class ChapterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FKSubjectId { get; set; }
        public SubjectDto Subject { get; set; }
        public IEnumerable<WebUserChapterUnlockDto> WebUserChapterUnlocks { get; set; }
    }
}
