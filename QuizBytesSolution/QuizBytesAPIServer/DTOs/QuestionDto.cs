namespace QuizBytesAPIServer.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Hint { get; set; }
        public int ChapterId { get; set; }
    }
}
