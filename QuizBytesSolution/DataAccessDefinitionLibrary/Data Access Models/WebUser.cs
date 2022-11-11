using System.Runtime.CompilerServices;

namespace DataAccessDefinitionLibrary.Data_Access_Models
{
    public class WebUser
    {
        public int PKWebUserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int TotalPoints { get; set; }
        public int AvailablePoints { get; set; }
        public string Email { get; set; }
        public int PointsAccumulatedInChallenge { get; set; }
        public int ElapsedSecondsInChallenge { get; set; }
        // public IEnumerable<WebUserChapterUnlock> WebUserChapterUnlocks { get; set; }
        
        public WebUser(string username, string password, string email, int totalPoints, int availablePoints, int id)
        {
            //constuctor for receiving and build an object -- why not just remove ID here since I don't think we'll need it?
            //don't wanna mess with code too much so I'll leave it like this for now.
            PKWebUserId = id;
            Username = username;
            PasswordHash = password;
            Email = email;
            TotalPoints = totalPoints;
            AvailablePoints = availablePoints;
        }

        public WebUser(string username, string password, string email, int totalPoints, int availablePoints)
        {
            //constructor for inserting a WebUser object + testing
            Username = username;
            PasswordHash = password;
            Email = email;
            TotalPoints = totalPoints;
            AvailablePoints = availablePoints;
        }
        public WebUser()
        {
                
        }
    }
}
