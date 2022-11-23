namespace QuizBytesAPIServer.DTOs;

public class QuizDto
{

    // 8 quiz questions for normal quizzes and 16 for challenge quizzes
    public IEnumerable<QuestionAnswerLinkDto> QuizQuestions { get; set; }

    // public QuizDto(IEnumerable<QuestionAnswerLinkDto> quizQuestions) => QuizQuestions = quizQuestions;


}
