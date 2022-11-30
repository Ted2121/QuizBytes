using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using NUnit.Framework;
using SQLAccessImplementationLibrary;
using Assert = NUnit.Framework.Assert;

namespace SQLAccessImplementationLibraryUnitTest;

[TestFixture]
public class ChapterDataAccessTests
{

    private IChapterDataAccess _chapterDataAccess = new ChapterDataAccess(Configuration.CONNECTION_STRING);
    private ISubjectDataAccess _subjectDataAccess = new SubjectDataAccess(Configuration.CONNECTION_STRING);
    private ICourseDataAccess _courseDataAccess = new CourseDataAccess(Configuration.CONNECTION_STRING);
    private Chapter _chapter;

    private int courseId = 0;
    private int subjectId = 0;

    private async Task CreateAndInsertObjectsAsync()
    {
        Course course = new Course()
        {
            Name = "TestCourse",
            Description = "test"
        };
        courseId = await _courseDataAccess.InsertCourseAsync(course);

        Subject subject = new Subject()
        {
            Name = "TestSubj",
            Description = "TestDesc",
            FKCourseId = courseId
        };
        subjectId = await _subjectDataAccess.InsertSubjectAsync(subject);

        Chapter chapter = new Chapter()
        {
            Name = "TestChapter",
            Description = "TestDescription",
            FKSubjectId = subjectId
        };
    }

    [SetUp]
    public async Task SetUp()
    {
        await CreateAndInsertObjectsAsync();

        _chapter = new()
        {
            Name = "TestChapter",
            Description = "TestDescription",
            FKSubjectId = subjectId
        };
    }

    [TearDown]
    public async Task TearDown()
    {
        await _chapterDataAccess.DeleteChapterAsync(_chapter.Id);
        await _subjectDataAccess.DeleteSubjectAsync(subjectId);
        await _courseDataAccess.DeleteCourseAsync(courseId);
    }

    [Test]
    public async Task TestingInsertChapterExpectingReturnedIdHigherThanZero()
    {
        // Arrange in setup

        // Act
        var userId = await _chapterDataAccess.InsertChapterAsync(_chapter);

        // Assert
        Assert.That(userId, Is.GreaterThan(0));
    }


}
