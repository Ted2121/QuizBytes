using WebApiClient;
using WebApiClient.DTOs;

namespace QuizBytesWebsite.Helpers;

public class CourseSelectionHelper : ICourseSelectionHelper
{
    private CourseFacadeApiClient CourseFacadeApiClient { get; set; }
    public CourseSelectionHelper(CourseFacadeApiClient courseFacadeApiClient)
    {
        CourseFacadeApiClient = courseFacadeApiClient;
    }

    // This overload is intended for testing so that we don't depend on the current time of day
    public async Task<CourseDto> GetCourseForChallenge(string day)
    {
        try
        {
            switch (day.ToLower())
            {
                case "monday":
                    return await CourseFacadeApiClient.GetCourseByIdAsync(1); //Programming
                case "tuesday":
                    return await CourseFacadeApiClient.GetCourseByIdAsync(2) ?? await CourseFacadeApiClient.GetCourseByIdAsync(1); //Technology or Programming
                case "wednesday":
                    return await CourseFacadeApiClient.GetCourseByIdAsync(3) ?? await CourseFacadeApiClient.GetCourseByIdAsync(1); //Dev Ops or Programming
                case "thursday":
                    return await CourseFacadeApiClient.GetCourseByIdAsync(4) ?? await CourseFacadeApiClient.GetCourseByIdAsync(1); // Computer World or Programming
                case "friday":
                    return await CourseFacadeApiClient.GetCourseByIdAsync(1); //Programming
                case "saturday":
                    return await CourseFacadeApiClient.GetCourseByIdAsync(2) ?? await CourseFacadeApiClient.GetCourseByIdAsync(1); //Technology or Programming
                case "sunday":
                    return await CourseFacadeApiClient.GetCourseByIdAsync(3) ?? await CourseFacadeApiClient.GetCourseByIdAsync(1); //Dev Ops or Programming
                default:
                    return null;
            }
        }
        catch (Exception ex)
        {

            throw new Exception($"Could not get the course for the challenge, Message was: {0}", ex);
        }
    }

    // Preferred overload for production - gets the course for the current day
    public async Task<CourseDto> GetCourseForChallenge()
    {
        try
        {
            switch ((int)DateTime.Now.DayOfWeek)
            {
                case 1:
                    return await CourseFacadeApiClient.GetCourseByIdAsync(1); //Programming
                case 2:
                    return await CourseFacadeApiClient.GetCourseByIdAsync(2) ?? await CourseFacadeApiClient.GetCourseByIdAsync(1); //Technology or Programming
                case 3:
                    return await CourseFacadeApiClient.GetCourseByIdAsync(3) ?? await CourseFacadeApiClient.GetCourseByIdAsync(1); //Dev Ops or Programming
                case 4:
                    return await CourseFacadeApiClient.GetCourseByIdAsync(4) ?? await CourseFacadeApiClient.GetCourseByIdAsync(1); // Computer World or Programming
                case 5:
                    return await CourseFacadeApiClient.GetCourseByIdAsync(1); //Programming
                case 6:
                    return await CourseFacadeApiClient.GetCourseByIdAsync(2) ?? await CourseFacadeApiClient.GetCourseByIdAsync(1); //Technology or Programming
                case 7:
                    return await CourseFacadeApiClient.GetCourseByIdAsync(3) ?? await CourseFacadeApiClient.GetCourseByIdAsync(1); //Dev Ops or Programming
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
