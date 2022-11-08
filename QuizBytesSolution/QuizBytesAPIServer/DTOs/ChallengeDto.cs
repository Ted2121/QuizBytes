namespace QuizBytesAPIServer.DTOs
{
    public class ChallengeDto
    {
        public int Id { get; set; }
        public CourseDto Course { get; set; }
        public QuizDto Quiz { get; set; }
        public int DurationInSeconds { get; set; }
        public IEnumerable<CurrentChallengeParticipantDto> Leaderboard { get; set; }
        public int FirstPlaceReward { get; private set; } = 256;
        public int SecondPlaceReward { get; private set; } = 128;
        public int ThirdPlaceReward { get; private set; } = 64;
        public int ParticipationReward { get; private set; } = 32;

    }
}
