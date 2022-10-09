using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.Models;

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
        public async Task<ActionResult> DeleteCourseAsync(Course course)
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
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCoursesAsync()
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
        public async Task<ActionResult<Course>> GetCourseByIdAsync(int courseId)
        {
            Course course = await CourseDataAccess.GetCourseByIdAsync(courseId);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> InsertCourseAsync(Course course)
        {
            course = await CourseDataAccess.InsertCourseAsync(course);

            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCourseAsync(Course course)
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
