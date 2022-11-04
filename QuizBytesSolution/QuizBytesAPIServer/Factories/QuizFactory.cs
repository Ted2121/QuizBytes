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
        public async Task<QuizDto> GetQuizDto<T>(string quizType, T source) where T : class
        {
            int numberOfQuestions;
            // Classic quizzes are from Chapters while Challenge quizzes are from whole Courses
            switch (quizType.ToLower())
            {
                case "classic":
                    numberOfQuestions = 8;
                    if(source is ChapterDto chapter)
                    {
                    var questionsFromChapterInQuiz = ShuffleAndTakeQuestions(await QuestionAnswerLinkFactory
                       .GetAllQuestionsWithAnswersByChapter(chapter), numberOfQuestions);

                    return new QuizDto(questionsFromChapterInQuiz);
                    }
                    else
                    {
                        throw new ArgumentException("A ChapterDto was expected as source");
                    }

                case "challenge":
                    numberOfQuestions = 16;
                    if(source is CourseDto course)
                    {
                        var questionsFromCourseInQuiz = ShuffleAndTakeQuestions(await QuestionAnswerLinkFactory
                       .GetAllQuestionsWithAnswersByCourse(course), numberOfQuestions);
                        return new QuizDto(questionsFromCourseInQuiz);
                    }
                    else
                    {
                        throw new ArgumentException("A CourseDto was expected as source");
                    }
                    

                default: throw new ArgumentException($"Type of quiz: {quizType} is invalid");

            }
        }

        private IEnumerable<QuestionAnswerLinkDto> ShuffleAndTakeQuestions(IEnumerable<QuestionAnswerLinkDto> questionAnswerLinkDtos, int numberOfQuestionsToTake)
        {
        
            return questionAnswerLinkDtos.Shuffle(numberOfQuestionsToTake);

        }
    }
}
