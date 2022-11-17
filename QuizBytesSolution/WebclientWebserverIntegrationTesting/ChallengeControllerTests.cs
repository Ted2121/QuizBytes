using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace WebclientWebserverIntegrationTesting
{
    [TestFixture]
    public class ChallengeControllerTests
    {
        IChallengeFacadeApiClient _challangeFacadeApiClient;

        [SetUp]
        public void SetUp()
        {
            _challangeFacadeApiClient = new ChallengeFacadeApiClient(Configuration.WEB_API_URI);
        }

        [TearDown]
        public void CleanUp()
        {

        }
        
    }
}
