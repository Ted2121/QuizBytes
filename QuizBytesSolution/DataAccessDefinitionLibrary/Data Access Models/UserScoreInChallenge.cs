namespace DataAccessDefinitionLibrary.DAO_models
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
