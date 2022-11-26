using WebApiClient;
using WebApiClient.DTOs;

namespace QuizBytesWebsite.Helpers;

public class CourseSelectionHelper : ICourseSelectionHelper
{

    private CourseFacadeApiClient CourseFacadeApiClient { get; set; }
    public Func<int> DayOfTheWeek { get; set; }
    public CourseSelectionHelper(CourseFacadeApiClient courseFacadeApiClient, Func<int> dayOfTheWeek = null)
    {
        CourseFacadeApiClient = courseFacadeApiClient;
        if (dayOfTheWeek == null)
        {
            dayOfTheWeek = () => (int)DateTime.Now.DayOfWeek;
        }
        DayOfTheWeek = dayOfTheWeek;
    }

    public async Task<CourseDto> GetCourseForChallenge() => await GetCourseForChallenge(DayOfTheWeek());

    public async Task<CourseDto> GetCourseForChallenge(int dayNumber)
    {
        try
        {
            switch (dayNumber)
            {
                case 1:
                case 6:
                    return await CourseFacadeApiClient.GetCourseByNameAsync("Programming"); //Programming
                case 2:
                case 5:
                    return await CourseFacadeApiClient.GetCourseByNameAsync("Technology") ?? await CourseFacadeApiClient.GetCourseByNameAsync("Programming"); //Technology or Programming
                case 3:
                case 7:
                    return await CourseFacadeApiClient.GetCourseByNameAsync("Dev Ops") ?? await CourseFacadeApiClient.GetCourseByNameAsync("Programming"); //Dev Ops or Programming
                case 4:
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
