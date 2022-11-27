using WebApiClient;
using WebApiClient.DTOs;

namespace QuizBytesWebsite.Helpers;

public class CourseSelectionHelper : ICourseSelectionHelper
{

    private ICourseFacadeApiClient CourseFacadeApiClient { get; set; }
    public Func<string> DayOfTheWeek { get; set; }
    public CourseSelectionHelper(ICourseFacadeApiClient courseFacadeApiClient, Func<string> dayOfTheWeek = null)
    {
        CourseFacadeApiClient = courseFacadeApiClient;
        if (dayOfTheWeek == null)
        {
            dayOfTheWeek = () => DateTime.Now.DayOfWeek.ToString();
        }
        DayOfTheWeek = dayOfTheWeek;
    }

    public async Task<CourseDto> GetCourseForChallenge() => await GetCourseForChallenge(DayOfTheWeek());

    public async Task<CourseDto> GetCourseForChallenge(string day)
    {
        try
        {
            switch (day.ToLower())
            {
                case "monday":
                case "saturday":
                    return await CourseFacadeApiClient.GetCourseByNameAsync("Programming"); //Programming
                case "tuesday":
                case "friday":
                    return await CourseFacadeApiClient.GetCourseByNameAsync("Technology") ?? await CourseFacadeApiClient.GetCourseByNameAsync("Programming"); //Technology or Programming
                case "wednesday":
                case "sunday":
                    return await CourseFacadeApiClient.GetCourseByNameAsync("Dev Ops") ?? await CourseFacadeApiClient.GetCourseByNameAsync("Programming"); //Dev Ops or Programming
                case "thursday":
                    return await CourseFacadeApiClient.GetCourseByNameAsync("Computer World") ?? await CourseFacadeApiClient.GetCourseByNameAsync("Programming"); // Computer World or Programming
                default:
                    return null;
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Could not get the course for the challenge, Message was: {0}", ex);
        }
    }


}
