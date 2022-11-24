using DataAccessDefinitionLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.DTOs
{
    public class WebUserDto
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"[^\s]+", ErrorMessage = "No spaces in username")]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"[^\s]+", ErrorMessage = "No spaces in password")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        [Required]
        [RegularExpression(@"[^\s]+", ErrorMessage = "No spaces in password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        public string Email { get; set; }
        public int TotalPoints { get; set; }
        public int AvailablePoints { get; set; }
        public int NumberOfCorrectAnswers { get; set; }
        public IEnumerable<ChapterDto>? WebUserChapterUnlocks { get; set; }
        public bool IsInChallenge { get; set; }
        //public int PointsAccumulatedInChallenge { get; set; }
        public int ElapsedSecondsInChallenge { get; set; }
    }
}
