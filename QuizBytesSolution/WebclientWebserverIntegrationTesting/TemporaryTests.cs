﻿using DataAccessDefinitionLibrary.DAO_Interfaces;
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
        WebUserDataAccess _webUserDataAccess = new WebUserDataAccess(Configuration.CONNECTION_STRING);
        CourseDataAccess _courseDataAccess = new CourseDataAccess(Configuration.CONNECTION_STRING); 
        ICurrentChallengeParticipantDataAccess _currentChallengeParticipantDataAccess = new CurrentChallengeParticipantDataAccessMock();

        [Test]
        public async Task ForceCleanUp()
        {
            //await _webUserDataAccess.DeleteWebUserAsync(234);
            //await _webUserDataAccess.DeleteWebUserAsync(235);

            //await _courseDataAccess.DeleteCourseAsync(227);
            //await _currentChallengeParticipantDataAccess.ClearTempTableBeforeNextChallengeAsync();

        }
    }
}
