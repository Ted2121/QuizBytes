using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.DTOs
{
    public class WebUserChallengeInfoDto
    {
        public int CorrectAnswers { get; set; }
        public int ElapsedTime { get; set; }
    }
}
