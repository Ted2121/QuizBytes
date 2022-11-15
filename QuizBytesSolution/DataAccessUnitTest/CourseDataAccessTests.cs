using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using NUnit.Framework;
using SQLAccessImplementationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _course = new Course("TestBob", "TestDescription");
            _courseDataAccess = new CourseDataAccess(Configuration.CONNECTION_STRING);
        }

        // tear down not possible because we don't have the id of the inserted course from the start

        [Test]
        public async Task TestingInsertionExpectingPositiveResult()
        {
            // Arrange is done in Set up


            // Act
             

            // Assert
        }
    }
}
