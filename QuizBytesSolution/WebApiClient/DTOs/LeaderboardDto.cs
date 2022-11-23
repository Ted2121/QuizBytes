using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.DTOs
{
    public class LeaderboardDto
    {
        public List<WebUserDto> Leaderboard { get; set; }
    }
}
