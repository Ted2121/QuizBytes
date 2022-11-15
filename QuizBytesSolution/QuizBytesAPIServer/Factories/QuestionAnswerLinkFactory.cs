using DataAccessDefinitionLibrary.DAO_Interfaces;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;

namespace QuizBytesAPIServer.Factories
{
    public class QuestionAnswerLinkFactory : IQuestionAnswerLinkFactory
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

        public async Task<IEnumerable<QuestionAnswerLinkDto>> GetAllQuestionsWithAnswersByChapter(ChapterDto chapterDto)
        {
            IEnumerable<QuestionDto> questionDtos = new List<QuestionDto>();
            // using an ICollection here to be able to add to the list
            ICollection<QuestionAnswerLinkDto> questionsToReturn = new List<QuestionAnswerLinkDto>();

            questionDtos = await GetAllQuestionsFromChapter(chapterDto);

            foreach (var questionDto in questionDtos)
            {
                questionsToReturn.Add(await LinkAnswersToQuestion(questionDto));
            }

            return questionsToReturn;
        }

        public async Task<IEnumerable<QuestionAnswerLinkDto>> GetAllQuestionsWithAnswersByCourse(CourseDto course)
        {
            IEnumerable<SubjectDto> subjectDtos = new List<SubjectDto>();
            IEnumerable<ChapterDto> chapterDtos = new List<ChapterDto>();
            IEnumerable<QuestionDto> questionDtos = new List<QuestionDto>();
            // using an ICollection here to be able to add to the list
            ICollection<QuestionAnswerLinkDto> questionsToReturn = new List<QuestionAnswerLinkDto>();

            subjectDtos = await GetAllSubjectsFromCourse(course);

            foreach (var subjectDto in subjectDtos)
            {
                chapterDtos = await GetAllChaptersFromSubject(subjectDto);

                foreach (var chapterDto in chapterDtos)
                {
                    questionDtos = await GetAllQuestionsFromChapter(chapterDto);

                    foreach (var questionDto in questionDtos)
                    {
                        questionsToReturn.Add(await LinkAnswersToQuestion(questionDto));
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

                ICollection<AnswerDto> answerDtos = new List<AnswerDto>();
                foreach (var answerModel in answerModels)
                {
                    answerDtos.Add(answerModel.ToDto());
                    questionAnswerLinkDto.Answers = answerDtos;
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

            ICollection<SubjectDto> subjectDTOs = new List<SubjectDto>();

            try
            {
                var subjectModels = await SubjectDataAccess.GetAllSubjectsByCourseAsync(course.FromDto());
                foreach (var subjectModel in subjectModels)
                {
                    subjectDTOs.Add(subjectModel.ToDto());
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
            ICollection<ChapterDto> chapterDtos = new List<ChapterDto>();

            try
            {
                var chapterModels = await ChapterDataAccess.GetAllChaptersBySubjectAsync(subject.FromDto());
                foreach (var chapterModel in chapterModels)
                {
                    chapterDtos.Add(chapterModel.ToDto());
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
            ICollection<QuestionDto> questionDtos = new List<QuestionDto>();

            try
            {
                var questionModels = await QuestionDataAccess.GetQuestionsByChapterAsync(chapter.FromDto());
                foreach (var questionModel in questionModels)
                {
                    questionDtos.Add(questionModel.ToDto());
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
