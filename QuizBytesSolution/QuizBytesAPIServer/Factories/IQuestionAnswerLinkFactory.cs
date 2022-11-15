using DataAccessDefinitionLibrary.DAO_Interfaces;
using QuizBytesAPIServer.DTOs;

namespace QuizBytesAPIServer.Factories
{
    public interface IQuestionAnswerLinkFactory
    {
        IAnswerDataAccess AnswerDataAccess { get; set; }
        IChapterDataAccess ChapterDataAccess { get; set; }
        IQuestionDataAccess QuestionDataAccess { get; set; }
        ISubjectDataAccess SubjectDataAccess { get; set; }

        Task<IEnumerable<QuestionAnswerLinkDto>> GetAllQuestionsWithAnswersByChapter(ChapterDto chapterDto);
        Task<IEnumerable<QuestionAnswerLinkDto>> GetAllQuestionsWithAnswersByCourse(CourseDto course);
    }
}