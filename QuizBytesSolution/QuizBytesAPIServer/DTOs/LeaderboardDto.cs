using System.ComponentModel.DataAnnotations;

namespace QuizBytesAPIServer.DTOs
{
    public class LeaderboardDto
    {
        public List<WebUserDto> Leaderboard { get; set; }
    }
}
