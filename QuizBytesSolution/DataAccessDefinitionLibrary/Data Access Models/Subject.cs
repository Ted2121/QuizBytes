namespace DataAccessDefinitionLibrary.Data_Access_Models;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int FKCourseId { get; set; }

    public Subject()
    {

    }
}
