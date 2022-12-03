using System.Timers;
using WebApiClient;

namespace QuizBytesWebsite.Helpers
{
    public interface ITimerLogicHelper
    {
        TimeSpan CalcTimeLeftUntilEvent();
        Task<TimeSpan> CleanUpCurrentChallengeOnTimeElapsed(IChallengeFacadeApiClient challengeFacadeApiClient);
    }
}