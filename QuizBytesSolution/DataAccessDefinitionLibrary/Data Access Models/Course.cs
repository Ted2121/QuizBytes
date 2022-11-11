namespace DataAccessDefinitionLibrary.Data_Access_Models
{
    public class Course
    {
        public int PKCourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // public IEnumerable<Subject> Subjects { get; set; }

        public Course(int id, string name, string description)
        {
            PKCourseId = id;
            Name = name;
            Description = description;
        }
    }
}
