namespace DataAccessDefinitionLibrary.DAO_models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentChallengeId { get; set; }
        public UserScoreInChallenge CurrentChallenge { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }

        public Course()
        {

        }
    }
}
