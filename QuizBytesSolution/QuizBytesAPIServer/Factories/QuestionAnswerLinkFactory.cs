using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;
using SQLAccessImplementationLibrary;

namespace QuizBytesAPIServer.Factories
{
    public class QuestionAnswerLinkFactory
    {
        public IAnswerDataAccess AnswerDataAccess { get; set; }
        public IQuestionDataAccess QuestionDataAccess { get; set; }
        public ISubjectDataAccess SubjectDataAccess { get; set; }
        public IChapterDataAccess ChapterDataAccess { get; set; }
        public QuestionAnswerLinkFactory(
        IAnswerDataAccess answerDataAccess, 
        IQuestionDataAccess questionDataAccess,
        ISubjectDataAccess subjectDataAccess,
        IChapterDataAccess chapterDataAccess)
        {
            AnswerDataAccess = answerDataAccess;
            QuestionDataAccess = questionDataAccess;
            SubjectDataAccess = subjectDataAccess;
            ChapterDataAccess = chapterDataAccess;
        }
        // TODO decide if we should have the question or the question id as parameter
        public static QuestionAnswerLinkDto GetQuestionAnswerLinkDto(QuestionDto question)
        {
            IEnumerable<AnswerDto> answers = AnswerDataAccess.GetAllAnswersByQuestionId(question.Id);

        }

        //public static IEnumerable<QuestionAnswerLinkDto> LinkMultipleQuestionsToAnswers

        private IEnumerable<QuestionDto> GetAllQuestionsByCourse(CourseDto course)
        {
            QuestionDataAccess.Ge
        }

        private async Task<IEnumerable<SubjectDto>> GetAllSubjectsFromCourse(CourseDto course)
        {
            IEnumerable<SubjectDto> subjectDTOs = new List<SubjectDto>();

            var subjectModels = await SubjectDataAccess.GetAllSubjectsByCourseAsync(course.FromDto());
            foreach(var subjectModel in subjectModels)
            {
                subjectDTOs.ToList().Add(subjectModel.ToDto());
            }

            return subjectDTOs;
            
        }

        private async Task<IEnumerable<ChapterDto>> GetAllChaptersFromSubject(SubjectDto subject)
        {
            IEnumerable<ChapterDto> chapterDtos = new List<ChapterDto>();

            var chapterModels = await ChapterDataAccess.GetAllChaptersBySubjectAsync(subject.FromDto());
            foreach (var chapterModel in chapterModels)
            {
                chapterDtos.ToList().Add(chapterModel.ToDto());
            }

            return chapterDtos;

        }

        private async Task<IEnumerable<QuestionDto>> GetAllQuestionsFromChapter(ChapterDto chapter)
        {
            IEnumerable<QuestionDto> questionDtos = new List<QuestionDto>();

            var questionModels = await QuestionDataAccess.GetAllQuestionsByChapterAsync(subject.FromDto());
            foreach (var chapterModel in chapterModels)
            {
                questionDtos.ToList().Add(chapterModel.ToDto());
            }

            return questionDtos;
        }
    }
}
