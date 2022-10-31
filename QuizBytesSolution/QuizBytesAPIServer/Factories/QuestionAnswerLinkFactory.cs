using DataAccessDefinitionLibrary.DAO_Interfaces;
using QuizBytesAPIServer.DTOs;
using SQLAccessImplementationLibrary;

namespace QuizBytesAPIServer.Factories
{
    public class QuestionAnswerLinkFactory
    {
        public IAnswerDataAccess AnswerDataAccess { get; set; }
        public QuestionAnswerLinkFactory(IAnswerDataAccess answerDataAccess)
        {
            AnswerDataAccess = answerDataAccess;
        }
        // TODO decide if we should have the question or the question id as parameter
        public static QuestionAnswerLinkDto GetQuestionAnswerLinkDto(QuestionDto question)
        {
            IEnumerable<AnswerDto> answers = AnswerDataAccess.GetAllAnswersByQuestionId(question.Id);

        }
    }
}
