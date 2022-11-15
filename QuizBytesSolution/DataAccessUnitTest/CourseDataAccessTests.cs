using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using NUnit.Framework;
using SQLAccessImplementationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace SQLAccessImplementationLibraryUnitTest
{
    [TestFixture]
    public class CourseDataAccessTests
    {
        Course _course;
        ICourseDataAccess _courseDataAccess;

        [SetUp]
        public void SetUp()
        {
            _course = new Course("Testy", "TestDescription");

            _courseDataAccess = new CourseDataAccess(Configuration.CONNECTION_STRING);
        }

        // tear down not possible because we don't have the id of the inserted course from the start

        [Test]
        public async Task TestingInsertionExpectingPositiveResultAsync()
        {
            // Arrange is done in Set up

            // Act
            _course.PKCourseId = await _courseDataAccess.InsertCourseAsync(_course);

            // Assert
            try
            {
                Assert.That(_course.PKCourseId, Is.GreaterThan(0));
            }
            finally
            {
                await _courseDataAccess.DeleteCourseAsync(_course.PKCourseId);
            }
        }

        [Test]
        public async Task TestingInsertionThrowsExceptionAsync()
        {

        }
       
    }
}
