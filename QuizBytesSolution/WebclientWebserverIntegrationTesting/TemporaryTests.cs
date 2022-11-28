using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using SQLAccessImplementationLibrary;
using SQLAccessImplementationLibraryUnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebclientWebserverIntegrationTesting
{
    [TestFixture]
    public class TemporaryTests
    {
        IWebUserDataAccess _webUserDataAccess = new WebUserDataAccess(Configuration.CONNECTION_STRING);
        ICourseDataAccess _courseDataAccess = new CourseDataAccess(Configuration.CONNECTION_STRING); 
        ICurrentChallengeParticipantDataAccess _currentChallengeParticipantDataAccess = new CurrentChallengeParticipantDataAccessMock();
        IAnswerDataAccess _answerDataAccess = new AnswerDataAccess(Configuration.CONNECTION_STRING);
        IQuestionDataAccess _questionDataAccess = new QuestionDataAccess(Configuration.CONNECTION_STRING);
        ISubjectDataAccess _subjectDataAccess = new SubjectDataAccess(Configuration.CONNECTION_STRING);
        IChapterDataAccess _chapterDataAccess = new ChapterDataAccess(Configuration.CONNECTION_STRING);

        Course course;
        Subject subject;
        Chapter chapter;

        Question question;
        Answer answer;



        [Test]
        public async Task ForceCleanUp()
        {
            //await _webUserDataAccess.DeleteWebUserAsync(78);
            //await _webUserDataAccess.DeleteWebUserAsync(265);

            //await _courseDataAccess.DeleteCourseAsync(72);
            await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();

        }

        //[Test]
        //public async Task CheesingInsertions()
        //{
        //    question = new Question()
        //    {
        //      FKChapterId = 21,
        //      QuestionText = "Which of the following is the best loop memory wise to run through a collection?"
        //    };
        //    await _questionDataAccess.InsertQuestionAsync(question);
        //}

        //[Test]
        //public async Task CheesingInsertionsTwo()
        //{
        //    answer = new Answer()
        //    {
        //        FKQuestionId = 396,
        //        AnswerText = "do…while loop",
        //        IsCorrect = "No"
        //    };
        //    await _answerDataAccess.InsertAnswerAsync(answer);
        //}

        //[Test]
        //public async Task CheesingInsertionsThree()
        //{
        //    answer = new Answer()
        //    {
        //        FKQuestionId = 396,
        //        AnswerText = "for loop",
        //        IsCorrect = "No"
        //    };
        //    await _answerDataAccess.InsertAnswerAsync(answer);
        //}

        //[Test]
        //public async Task CheesingInsertionsFour()
        //{
        //    answer = new Answer()
        //    {
        //        FKQuestionId = 396,
        //        AnswerText = "foreach loop",
        //        IsCorrect = "Yes"
        //    };
        //    await _answerDataAccess.InsertAnswerAsync(answer);
        //}


        //[Test]
        //public async Task CheesingInsertionsFive()
        //{
        //    answer = new Answer()
        //    {
        //        FKQuestionId = 396,
        //        AnswerText = "while loop",
        //        IsCorrect = "No"
        //    };
        //    await _answerDataAccess.InsertAnswerAsync(answer);
        //}

        //[Test]
        //public async Task DeleteMistake()
        //{
        //    await _answerDataAccess.DeleteAnswerAsync(1546);
        //}

    }
}
