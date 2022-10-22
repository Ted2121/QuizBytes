using DataAccessDefinitionLibrary.DAO_Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.Models;
using Answer = QuizBytesAPIServer.Models.Answer;
using Chapter = QuizBytesAPIServer.Models.Chapter;
using Course = QuizBytesAPIServer.Models.Course;
using CurrentChallenge = QuizBytesAPIServer.Models.CurrentChallenge;
using Question = QuizBytesAPIServer.Models.Question;
using Subject = QuizBytesAPIServer.Models.Subject;
using WebUserChapterUnlocks = QuizBytesAPIServer.Models.WebUserChapterUnlocks;
using WebUser = QuizBytesAPIServer.Models.WebUser;

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
        public async Task<ActionResult> DeleteSubjectAsync(Subject subject)
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
        public async Task<ActionResult<IEnumerable<Subject>>> GetAllSubjectsAsync()
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
        public async Task<ActionResult<IEnumerable<Subject>>> GetAllSubjectsByCourseAsync(Course course)
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
        public async Task<ActionResult<Subject>> GetSubjectByIdAsync(int subjectId)
        {
            Subject subject = await SubjectDataAccess.GetSubjectByIdAsync(subjectId);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPost]
        public async Task<ActionResult<Subject>> InsertSubjectAsync(Subject subject)
        {
            subject = await SubjectDataAccess.InsertSubjectAsync(subject);

            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSubjectAsync(Subject subject)
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
