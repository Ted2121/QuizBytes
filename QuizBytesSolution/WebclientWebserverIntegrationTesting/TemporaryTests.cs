using SQLAccessImplementationLibrary;
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

        [Test]
        public async Task ForceCleanUp()
        {
            //await _webUserDataAccess.DeleteWebUserAsync(116);
            //await _webUserDataAccess.DeleteWebUserAsync(139);
            await _courseDataAccess.DeleteCourseAsync(163);


        }
    }
}
