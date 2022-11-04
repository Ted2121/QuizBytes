namespace QuizBytesAPIServer.DTOs
{
    public class CurrentChallengeDto
    {
        public int Id { get; set; }
        public CourseDto Course { get; set; }
        public QuizDto Quiz { get; set; }
        public int DurationInSeconds { get; set; }
        public IEnumerable<WebUserDto> Leaderboard { get; set; }
        public int FirstPlaceReward { get; set; } = 256;
        public int SecondPlaceReward { get; set; } = 128;
        public int ThirdPlaceReward { get; set; } = 64;
        public int ParticipationReward { get; set; } = 32;

    }
}
