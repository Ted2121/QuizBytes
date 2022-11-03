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

        
        public async Task<IEnumerable<QuestionAnswerLinkDto>> GetAllQuestionsWithAnswersByCourse(CourseDto course)
        {
            IEnumerable<SubjectDto> subjectDtos = new List<SubjectDto>();
            IEnumerable<ChapterDto> chapterDtos = new List<ChapterDto>();
            IEnumerable<QuestionDto> questionDtos = new List<QuestionDto>();

            IEnumerable<QuestionAnswerLinkDto> questionsToReturn = new List<QuestionAnswerLinkDto>();

            subjectDtos = await GetAllSubjectsFromCourse(course);

            foreach(var subjectDto in subjectDtos)
            {
                chapterDtos = await GetAllChaptersFromSubject(subjectDto);

                foreach(var chapterDto in chapterDtos)
                {
                    questionDtos = await GetAllQuestionsFromChapter(chapterDto);

                    foreach(var questionDto in questionDtos)
                    {
                        questionsToReturn.ToList().Add(await LinkAnswersToQuestion(questionDto));
                    }
                }
            }

            return questionsToReturn;

        }
        private async Task<QuestionAnswerLinkDto> LinkAnswersToQuestion(QuestionDto question)
        {
            try
            {
            QuestionAnswerLinkDto questionAnswerLinkDto = new QuestionAnswerLinkDto();
            questionAnswerLinkDto.Question = question;
            var answerModels = await AnswerDataAccess.GetAllAnswersByQuestionIdAsync(question.FromDto().PKQuestionId);
            foreach(var answerModel in answerModels)
            {
                questionAnswerLinkDto.Answers.ToList().Add(answerModel.ToDto());
            }
            return questionAnswerLinkDto;

            }
            catch (Exception ex)
            {
                throw new Exception($"Exception while trying to link the question with id: {question.Id} to the answers associated with it. The exception was: '{ex.Message}'", ex);
            }
        }

        private async Task<IEnumerable<SubjectDto>> GetAllSubjectsFromCourse(CourseDto course)
        {
            IEnumerable<SubjectDto> subjectDTOs = new List<SubjectDto>();

            try
            {
            var subjectModels = await SubjectDataAccess.GetAllSubjectsByCourseAsync(course.FromDto());
            foreach(var subjectModel in subjectModels)
            {
                subjectDTOs.ToList().Add(subjectModel.ToDto());
            }

            return subjectDTOs;

            }
            catch (Exception ex)
            {
                throw new Exception($"Exception while trying to get all subjects from the course: {course.Name}. The exception was: '{ex.Message}'", ex);
            }
            
        }

        private async Task<IEnumerable<ChapterDto>> GetAllChaptersFromSubject(SubjectDto subject)
        {
            IEnumerable<ChapterDto> chapterDtos = new List<ChapterDto>();

            try
            {
            var chapterModels = await ChapterDataAccess.GetAllChaptersBySubjectAsync(subject.FromDto());
            foreach (var chapterModel in chapterModels)
            {
                chapterDtos.ToList().Add(chapterModel.ToDto());
            }

            return chapterDtos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception while trying to get all chapters from the subject: {subject.Name}. The exception was: '{ex.Message}'", ex);
            }
        }

        private async Task<IEnumerable<QuestionDto>> GetAllQuestionsFromChapter(ChapterDto chapter)
        {
            IEnumerable<QuestionDto> questionDtos = new List<QuestionDto>();

            try
            {
                var questionModels = await QuestionDataAccess.GetQuestionsByChapterAsync(chapter.FromDto());
            foreach (var questionModel in questionModels)
            {
                questionDtos.ToList().Add(questionModel.ToDto());
            }

            return questionDtos;

            }
            catch (Exception ex)
            {
                throw new Exception($"Exception while trying to get all questions from the chapter: {chapter.Name}. The exception was: '{ex.Message}'", ex);
            }
        }
    }
}
