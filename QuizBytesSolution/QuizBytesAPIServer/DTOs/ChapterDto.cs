namespace QuizBytesAPIServer.DTOs;

public class ChapterDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int FkSubjectId { get; set; }
    public int UnlockPrice { get; private set; } = 256;
    
}
