namespace DataAccessDefinitionLibrary.Data_Access_Models
{
    public class UserScoreInChallenge
    {
        
        public int WebUserId { get; set; }
        public int FKCourseId { get; set; }
        public int PointsAccumulated { get; set; }
        public int ElapsedSeconds { get; set; }

        public UserScoreInChallenge()
        {

        }
    }
}
