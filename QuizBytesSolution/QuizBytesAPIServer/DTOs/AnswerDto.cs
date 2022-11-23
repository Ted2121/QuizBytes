namespace QuizBytesAPIServer.DTOs;

public class AnswerDto
{
    public int Id { get; set; }
    public string IsCorrect { get; set; }
    public string AnswerText { get; set; }
    public int FkQuestionId { get; set; }
}
