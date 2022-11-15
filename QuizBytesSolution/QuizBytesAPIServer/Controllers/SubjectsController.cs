using DataAccessDefinitionLibrary.DAO_Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;
using SQLAccessImplementationLibrary;

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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAllSubjectsAsync()
        {
            var subjects = await SubjectDataAccess.GetAllSubjectsAsync();

            if (subjects == null)
            {
                return NotFound();
            }
            return Ok(subjects.ToDtos());
        }

        [HttpGet]
        [Route("course")]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetAllSubjectsByCourseAsync([FromQuery] CourseDto course)
        {
            var subjects = await SubjectDataAccess.GetAllSubjectsByCourseAsync(course.FromDto());

            if (subjects == null)
            {
                return NotFound();
            }
            return Ok(subjects.ToDtos());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SubjectDto>> GetSubjectByIdAsync(int subjectId)
        {
            var subject = await SubjectDataAccess.GetSubjectByIdAsync(subjectId);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject.ToDto());
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteSubjectAsync(int id)
        {

            if (!await SubjectDataAccess.DeleteSubjectAsync(id))
            { return NotFound(); }
            else
            { return Ok(); }

        }

        [HttpPost]
        public async Task<ActionResult<SubjectDto>> InsertSubjectAsync([FromBody] SubjectDto subject)
        {
            if (subject == null)
            {
                return NotFound();
            }
            await SubjectDataAccess.InsertSubjectAsync(subject.FromDto());

            return Ok(subject);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSubjectAsync([FromBody] SubjectDto subject)
        {

            if (subject == null || !await SubjectDataAccess.UpdateSubjectAsync(subject.FromDto()))
            {
                return NotFound();
            }

            return Ok();

        }
    }
}
