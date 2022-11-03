using DataAccessDefinitionLibrary.Data_Access_Models;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.Extension_Methods;

namespace QuizBytesAPIServer.Factories
{
    public class QuizFactory
    {
        public QuestionAnswerLinkFactory QuestionAnswerLinkFactory { get; set; }
        public QuizFactory(QuestionAnswerLinkFactory questionAnswerLinkFactory)
        {
            QuestionAnswerLinkFactory = questionAnswerLinkFactory;
        }
        public async Task<QuizDto> GetQuizDto<T>(string quizType, T source)
        {
            int numberOfQuestions;
            // Classic quizzes are from Chapters while Challenge quizzes are from whole Courses
            switch (quizType.ToLower())
            {
                case "classic":
                    numberOfQuestions = 8;

                    var questionsFromChapterInQuiz = ShuffleAndTakeQuestions(await QuestionAnswerLinkFactory
                       .GetAllQuestionsWithAnswersByChapter(chapter), numberOfQuestions);
                    return new QuizDto(questionsFromChapterInQuiz);

                case "challenge":
                    numberOfQuestions = 16;

                    var questionsFromCourseInQuiz = ShuffleAndTakeQuestions(await QuestionAnswerLinkFactory
                       .GetAllQuestionsWithAnswersByCourse(course), numberOfQuestions);
                    return new QuizDto(questionsFromCourseInQuiz);

                default: throw new ArgumentException($"Type of quiz: {quizType} is invalid");

            }
        }

        private IEnumerable<QuestionAnswerLinkDto> ShuffleAndTakeQuestions(IEnumerable<QuestionAnswerLinkDto> questionAnswerLinkDtos, int numberOfQuestionsToTake)
        {
            
            return questionAnswerLinkDtos.Shuffle(numberOfQuestionsToTake);

        }
    }
}
