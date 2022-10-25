namespace QuizBytesAPIServer.DTOs
{
    public class QuestionAnswerLinkDto
    {
        public int QuestionAnswerLinkId { get; set; }
        public QuestionDto Question { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
        public int PointReward { get; set; }
    }
}
