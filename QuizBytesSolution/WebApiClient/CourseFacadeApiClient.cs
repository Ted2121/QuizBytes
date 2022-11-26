using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.DTOs;
using WebApiClient.Extensions;

namespace WebApiClient;

public class CourseFacadeApiClient : ICourseFacadeApiClient
{
    private RestClient _restClient;

    public CourseFacadeApiClient(string uri) => _restClient = new RestClient(uri);

    public async Task<IEnumerable<CourseDto>> GetAllCoursesAsync()
    {
        var response = await _restClient.RequestAsync<IEnumerable<CourseDto>>(Method.GET, $"Courses");

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error getting all courses. Message was {response.Content}");
        }

        return response.Data;
    }

    public async Task<CourseDto> GetCourseByIdAsync(int id)
    {
        var response = await _restClient.RequestAsync<CourseDto>(Method.GET, $"Courses/{id}");

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error getting the course with the id {id}. Message was {response.Content}");
        }

        return response.Data;
    }

    public async Task<CourseDto> GetCourseByNameAsync(string name)
    {
        var response = await _restClient.RequestAsync<CourseDto>(Method.GET, $"Courses/{name}");

        if (!response.IsSuccessful)
        {
            throw new Exception($"Error getting the course with the id {name}. Message was {response.Content}");
        }

        return response.Data;
    }


}
