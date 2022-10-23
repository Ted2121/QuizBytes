using DataAccessDefinitionLibrary.DAO_Interfaces;
using Microsoft.AspNetCore.Mvc;
using Answer = QuizBytesAPIServer.DTOs.AnswerDTO;
using Chapter = QuizBytesAPIServer.DTOs.ChapterDto;
using CourseDto = QuizBytesAPIServer.DTOs.CourseDto;
using CurrentChallenge = QuizBytesAPIServer.DTOs.CurrentChallengeDto;
using Question = QuizBytesAPIServer.DTOs.QuestionDto;
using SubjectDto = QuizBytesAPIServer.DTOs.SubjectDto;
using WebUserChapterUnlocks = QuizBytesAPIServer.DTOs.WebUserChapterUnlocksDto;
using WebUser = QuizBytesAPIServer.DTOs.WebUserDto;

namespace QuizBytesAPIServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SubjectsController : ControllerBase
    {
        public ISubjectDataAccess SubjectDataAccess { get; set; }

        public SubjectsController(ISubjectDataAccess subjectDataAccess)
        {
            SubjectDataAccess = subjectDataAccess;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteSubjectAsync(SubjectDto subject)
        {
            if (subject == null)
            {
                return NotFound();
            }

            await SubjectDataAccess.DeleteSubjectAsync(subject);
            // TODO figure out how to check if deletion was successfull

            return Ok();
        }

        [HttpGet]
        [Route("{all}")]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAllSubjectsAsync()
        {
            var subjects = await SubjectDataAccess.GetAllSubjectsAsync();

            if (subjects == null)
            {
                return NotFound();
            }
            return Ok(subjects);
        }

        [HttpGet]
        [Route("course")]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAllSubjectsByCourseAsync(CourseDto course)
        {
            var subjects = await SubjectDataAccess.GetAllSubjectsByCourseAsync();

            if (subjects == null)
            {
                return NotFound();
            }
            return Ok(subjects);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SubjectDto>> GetSubjectByIdAsync(int subjectId)
        {
            SubjectDto subject = await SubjectDataAccess.GetSubjectByIdAsync(subjectId);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult<SubjectDto>> InsertSubjectAsync(SubjectDto subject)
        {
            subject = await SubjectDataAccess.InsertSubjectAsync(subject);

            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSubjectAsync(SubjectDto subject)
        {

            if (subject == null)
            {
                return NotFound();
            }

            await SubjectDataAccess.UpdateSubjectAsync(subject);

            return Ok();

        }
    }
}
