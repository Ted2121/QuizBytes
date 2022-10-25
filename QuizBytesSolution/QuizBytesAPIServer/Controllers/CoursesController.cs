using Microsoft.AspNetCore.Mvc;
using Chapter = QuizBytesAPIServer.DTOs.ChapterDto;
using CourseDto = QuizBytesAPIServer.DTOs.CourseDto;
using CurrentChallenge = QuizBytesAPIServer.DTOs.CurrentChallengeDto;
using Question = QuizBytesAPIServer.DTOs.QuestionDto;
using Subject = QuizBytesAPIServer.DTOs.SubjectDto;
using WebUserChapterUnlocks = QuizBytesAPIServer.DTOs.WebUserChapterUnlocksDto;
using WebUser = QuizBytesAPIServer.DTOs.WebUserDto;
using DataAccessDefinitionLibrary.DAO_Interfaces;

namespace QuizBytesAPIServer.Controllers
{
    [ApiController]
        [Route("api/v1/[controller]")]
    public class CoursesController : ControllerBase
    {
        public ICourseDataAccess CourseDataAccess { get; set; }

        public CoursesController(ICourseDataAccess courseDataAccess)
        {
            CourseDataAccess = courseDataAccess;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCourseAsync(CourseDto course)
        {
            if (course == null)
            {
                return NotFound();
            }

            await CourseDataAccess.DeleteCourseAsync(course);
            // TODO figure out how to check if deletion was successfull

            return Ok();
        }

        [HttpGet]
        [Route("{all}")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCoursesAsync()
        {
            var courses = await CourseDataAccess.GetAllCoursesAsync();

            if (courses == null)
            {
                return NotFound();
            }
            return Ok(courses);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourseByIdAsync(int courseId)
        {
            CourseDto course = await CourseDataAccess.GetCourseByIdAsync(courseId);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> InsertCourseAsync(CourseDto course)
        {
            course = await CourseDataAccess.InsertCourseAsync(course);

            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCourseAsync(CourseDto course)
        {

            if (course == null)
            {
                return NotFound();
            }

            await CourseDataAccess.UpdateCourseAsync(course);

            return Ok();

        }
    }
}
