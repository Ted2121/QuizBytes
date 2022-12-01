using DataAccessDefinitionLibrary.Data_Access_Models;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.Extension_Methods;

namespace QuizBytesAPIServer.Factories;

public class QuizFactory : IQuizFactory
{
    public IQuestionAnswerLinkFactory QuestionAnswerLinkFactory { get; set; }
    public QuizFactory(IQuestionAnswerLinkFactory questionAnswerLinkFactory)
    {
        QuestionAnswerLinkFactory = questionAnswerLinkFactory;
    }

    public async Task<QuizDto> CreateQuizDto<T>(T source) where T : class
    {
        int numberOfQuestions;

        // Classic quizzes are from Chapters while Challenge quizzes are from whole Courses
        switch (source)
        {
            case ChapterDto chapter:
                numberOfQuestions = 8;
                var questionsFromChapterInQuiz = ShuffleAndTakeQuestions(await QuestionAnswerLinkFactory
                    .GetAllQuestionsWithAnswersByChapter(chapter), numberOfQuestions);
                var quizFromChapter = new QuizDto();
                quizFromChapter.QuizQuestions = questionsFromChapterInQuiz;
                return quizFromChapter;

            case CourseDto course:
                // changed to 8 instead of 16 for demo purposes
                numberOfQuestions = 8;
                var questionsFromCourseInQuiz = ShuffleAndTakeQuestions(await QuestionAnswerLinkFactory
                .GetAllQuestionsWithAnswersByCourse(course), numberOfQuestions);
                var quizFromCourse = new QuizDto();
                quizFromCourse.QuizQuestions = questionsFromCourseInQuiz;
                return quizFromCourse;

            default:
                throw new ArgumentException($"Invalid source type: {source.GetType()}");
        }
    }

    private IEnumerable<QuestionAnswerLinkDto> ShuffleAndTakeQuestions(IEnumerable<QuestionAnswerLinkDto> questionAnswerLinkDtos, int numberOfQuestionsToTake)
    {

        return questionAnswerLinkDtos.Shuffle(numberOfQuestionsToTake);

    }
}
