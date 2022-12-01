using System.ComponentModel.DataAnnotations;

namespace QuizBytesAPIServer.DTOs;

public class QuizDto
{
    public IEnumerable<QuestionAnswerLinkDto> QuizQuestions { get; set; }
}
