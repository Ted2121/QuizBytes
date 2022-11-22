using DataAccessDefinitionLibrary.Data_Access_Models;
using QuizBytesAPIServer.DTOs;

namespace APITests;
public static class DtoConverterForTests
    {


        public static WebUserDto ToDto(this WebUser webUserToConvert)
        {
            var webUserDto = new WebUserDto();
            webUserToConvert.CopyPropertiesTo(webUserDto);
            return webUserDto;
        }

        public static WebUser FromDto(this WebUserDto webUserDtoToConvert)
        {
            var webUser = new WebUser();
            webUserDtoToConvert.CopyPropertiesTo(webUser);
            return webUser;
        }

        public static CourseDto ToDto(this Course courseToConvert)
        {
            var courseDto = new CourseDto();
            courseToConvert.CopyPropertiesTo(courseDto);
            return courseDto;
        }

        public static Course FromDto(this CourseDto courseDtoToConvert)
        {
            var course = new Course();
            courseDtoToConvert.CopyPropertiesTo(course);
            return course;
        }
    }

