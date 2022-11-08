namespace QuizBytesAPIServer.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentChallengeId { get; set; }
        public ChallengeDto CurrentChallenge { get; set; }
        public IEnumerable<SubjectDto> Subjects { get; set; }
    }
}
