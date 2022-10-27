using System.Runtime.CompilerServices;

namespace DataAccessDefinitionLibrary.Data_Access_Models
{
    public class WebUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int TotalPoints { get; set; }
        public int AvailablePoints { get; set; }
        public UserScoreInChallenge ScoreInCurrentChallenge { get; set; }
        public IEnumerable<WebUserChapterUnlock> WebUserChapterUnlocks { get; set; }
        
        public WebUser(string username, string password, string email, int totalPoints, int availablePoints)
        {
            
            Username = username;
            Password = password;
            Email = email;
            TotalPoints = totalPoints;
            AvailablePoints = availablePoints;
        }

        public WebUser()
        {

        }
    }
}
