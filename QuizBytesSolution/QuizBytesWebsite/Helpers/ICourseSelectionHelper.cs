using WebApiClient.DTOs;

namespace QuizBytesWebsite.Helpers
{
    public interface ICourseSelectionHelper
    {
        Func<string> DayOfTheWeek { get; set; }

        Task<CourseDto> GetCourseForChallenge();
        Task<CourseDto> GetCourseForChallenge(string day);
    }
}