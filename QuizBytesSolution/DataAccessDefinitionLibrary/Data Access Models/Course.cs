namespace DataAccessDefinitionLibrary.Data_Access_Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }

        public Course()
        {

        }
    }
}
