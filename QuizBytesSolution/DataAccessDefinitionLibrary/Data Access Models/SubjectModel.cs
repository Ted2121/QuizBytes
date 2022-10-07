namespace DataAccessDefinitionLibrary.DAO_models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FKCourseId { get; set; }
        public CourseModel Course { get; set; }
        public IEnumerable<ChapterModel> Chapters { get; set; }
    }
}
