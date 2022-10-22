namespace DataAccessDefinitionLibrary.DAO_models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FKCourseId { get; set; }
        public Course Course { get; set; }
        public IEnumerable<Chapter> Chapters { get; set; }
    }
}
