namespace QuizBytesWebsite.Models
{
    public class LeaderboardModel
    {

        public List<LeaderboardInfo>? Leaderboard { get; set; }

        public LeaderboardModel()
        {
            Leaderboard = new List<LeaderboardInfo>();
        }
    }
}
