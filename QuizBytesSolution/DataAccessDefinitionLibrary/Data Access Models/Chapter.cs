namespace DataAccessDefinitionLibrary.Data_Access_Models;

public class Chapter
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int FKSubjectId { get; set; }
    public string Description { get; set; }
    
    // This constructor is for insertion with identity constraint
    public Chapter(string name, string description, int fKSubjectId)
    {
        Name = name;
        Description = description;
        FKSubjectId = fKSubjectId;
    }

    public Chapter()
    {
    }
}
