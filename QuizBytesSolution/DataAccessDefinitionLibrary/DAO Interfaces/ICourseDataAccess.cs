﻿using DataAccessDefinitionLibrary.DAO_models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface ICourseDataAccess
    {
        Task<Course> InsertCourseAsync(Course course);
        Task<Course> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(Course course);
    }
}
