namespace QuizBytesAPIServer.DTOs
{
    public class QuestionAnswerLinkDto
    {
        // TODO decide this
        // Don't think we need this id, we don't store this anywhere nor we need to find it by id
        //public int QuestionAnswerLinkId { get; set; }
        public QuestionDto Question { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
        public int PointReward { get; set; }
    }
}
