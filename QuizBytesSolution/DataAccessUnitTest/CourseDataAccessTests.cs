using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using NUnit.Framework;
using NUnit.Framework.Constraints;
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
        Course _courseWithoutName;
        ICourseDataAccess _courseDataAccess;

        [SetUp]
        public void SetUp()
        {
            _course = new Course("Testy", "TestDescription");
            _courseWithoutName = new Course(null, "TestDescription");

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
        public async Task TestingInsertionThrowsExceptionOnNullNameAsync()
        {
            // Arrange is done in Set up

            // Act & Assert
            try
            {
                Assert.That(async () => await _courseDataAccess.InsertCourseAsync(_courseWithoutName), Throws.Exception);
            }
            finally
            {
                await _courseDataAccess.DeleteCourseAsync(_course.PKCourseId);
            }

        }

        [Test]
        public async Task TestingGetCourseByIdReturnsTheCorrectCourse()
        {
            // Arrange
            _course.PKCourseId = await _courseDataAccess.InsertCourseAsync(_course);

            // Act
            var actual = await _courseDataAccess.GetCourseByIdAsync(_course.PKCourseId);

            // Assert
            try
            {
                Assert.That(actual, Is.Not.Null);
            }
            finally
            {
                await _courseDataAccess.DeleteCourseAsync(_course.PKCourseId);
            }
        }

        [Test]
        public async Task TestingGetCourseByIdReturnsNullIfThereIsNoUserWithId()
        {
            // Arrange
            _course.PKCourseId = await _courseDataAccess.InsertCourseAsync(_course);

            // Act
            var actual = await _courseDataAccess.GetCourseByIdAsync(_course.PKCourseId + 100);

            try
            {
            // Assert
            Assert.That(actual, Is.Null);

            }
            finally
            {
                await _courseDataAccess.DeleteCourseAsync(_course.PKCourseId);
            }
        }
    }
}
