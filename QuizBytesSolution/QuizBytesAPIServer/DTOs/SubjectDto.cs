namespace QuizBytesAPIServer.DTOs
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        public CourseDto Course { get; set; }
        public IEnumerable<ChapterDto> Chapters { get; set; }
    }
}
