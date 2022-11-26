
using WebApiClient.DTOs;

namespace WebApiClient;

public interface ICourseFacadeApiClient
{
    Task<IEnumerable<CourseDto>> GetAllCoursesAsync();
    Task<CourseDto> GetCourseByIdAsync(int id);
}