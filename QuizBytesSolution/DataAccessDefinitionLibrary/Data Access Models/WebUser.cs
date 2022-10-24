using System.Runtime.CompilerServices;

namespace DataAccessDefinitionLibrary.DAO_models
{
    public class WebUser
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int TotalPoints { get; set; }
        public int AvailablePoints { get; set; }
        public IEnumerable<WebUserChapterUnlocks> WebUserChapterUnlocks { get; set; }
        
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
