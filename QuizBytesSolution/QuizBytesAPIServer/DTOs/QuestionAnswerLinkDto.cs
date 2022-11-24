using System.ComponentModel.DataAnnotations;

namespace QuizBytesAPIServer.DTOs;

public class QuestionAnswerLinkDto
{
    public QuestionDto Question { get; set; }
    public IEnumerable<AnswerDto> Answers { get; set; }
    
}
