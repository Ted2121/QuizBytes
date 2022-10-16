namespace DataAccessDefinitionLibrary.DAO_models
{
    public class WebUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int TotalPoints { get; set; }
        public int AvailablePoints { get; set; }
        
        public WebUser(string username, string password, string email, int totalPoints, int availablePoints)
        {
            Username = username;
            Password = password;
            Email = email;
            TotalPoints = totalPoints;
            AvailablePoints = availablePoints;
            //should availablepoints and totalpoints be here and if yes should there be a default value like
            //100 starting points that we give to the webusers for free
            //^^ this could also be easily handled in the UI by setting a base value for the text box
            //which can then be altered if there is a need to do so

        }
    }
}
