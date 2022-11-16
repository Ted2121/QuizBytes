using QuizBytesAPIServer.DTOs;

namespace QuizBytesAPIServer.Factories;

public interface IQuizFactory
{
    IQuestionAnswerLinkFactory QuestionAnswerLinkFactory { get; set; }

    Task<QuizDto> CreateQuizDto<T>(T source) where T : class;
}