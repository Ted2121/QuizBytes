namespace DataAccessDefinitionLibrary.DAO_models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentChallengeId { get; set; }
        public CurrentChallengeModel CurrentChallenge { get; set; }
        public IEnumerable<SubjectModel> Subjects { get; set; }
    }
}
