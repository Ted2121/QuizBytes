using DataAccessDefinitionLibrary.Data_Access_Models;

namespace QuizBytesAPIServer.DTOs;

public class WebUserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int TotalPoints { get; set; }
    public int AvailablePoints { get; set; }
    public int NumberOfCorrectAnswers { get; set; }
    public IEnumerable<WebUserChapterUnlock> WebUserChapterUnlocks { get; set; }
    public bool IsInChallenge { get; set; }
}
