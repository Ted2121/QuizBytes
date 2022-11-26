using WebApiClient;
using WebApiClient.DTOs;

namespace QuizBytesWebsite.Helpers
{
    public interface ICourseSelectionHelper
    {
        Task<CourseDto> GetCourseForChallenge();
        Task<CourseDto> GetCourseForChallenge(string day);
    }
}