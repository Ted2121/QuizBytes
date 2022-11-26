using WebApiClient.DTOs;

namespace QuizBytesWebsite.Helpers
{
    public interface ICourseSelectionHelper
    {
        Func<int> DayOfTheWeek { get; set; }

        Task<CourseDto> GetCourseForChallenge();
        Task<CourseDto> GetCourseForChallenge(int dayNumber);
    }
}