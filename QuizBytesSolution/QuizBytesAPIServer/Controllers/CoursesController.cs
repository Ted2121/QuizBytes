using Microsoft.AspNetCore.Mvc;

using DataAccessDefinitionLibrary.DAO_Interfaces;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;

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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCoursesAsync()
        {
            var courses = await CourseDataAccess.GetAllCoursesAsync();

            if (courses == null)
            {
                return NotFound();
            }
            return Ok(courses.ToDtos());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourseByIdAsync([FromQuery] int courseId)
        {
            var course = await CourseDataAccess.GetCourseByIdAsync(courseId);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course.ToDto());
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCourseAsync([FromBody] CourseDto course)
        {
            if (course == null)
            {
                return NotFound();
            }

            //await CourseDataAccess.DeleteCourseAsync(course.FromDto());

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<CourseDto>> InsertCourseAsync([FromBody] CourseDto course)
        {
            if (course == null)
            {
                return NotFound();
            }
            var courseModel = await CourseDataAccess.InsertCourseAsync(course.FromDto());
            return Ok(course);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCourseAsync([FromBody] CourseDto course)
        {

            if (course == null)
            {
                return NotFound();
            }

            await CourseDataAccess.UpdateCourseAsync(course.FromDto());

            return Ok();

        }
    }
}
