namespace DataAccessDefinitionLibrary.Data_Access_Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Course(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Course(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public Course()
    {
    }
}
