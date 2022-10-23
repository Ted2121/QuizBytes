namespace DataAccessDefinitionLibrary.DAO_models
{
    public class CurrentChallenge
    {

        public string WebUserUserName { get; set; }
        public int FKCourseId { get; set; }
        public int PointsAccumulated { get; set; }
        public int ElapsedSeconds { get; set; }

        public CurrentChallenge()
        {

        }
    }
}
