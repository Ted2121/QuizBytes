namespace QuizBytesAPIServer.DTOs
{
    public class CurrentChallengeDto
    {
        public IEnumerable<String> webuserUsername { get; set; }
        public int FKCourseId { get; set; }
    }
}
