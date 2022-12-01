using System.Timers;
using WebApiClient;

namespace QuizBytesWebsite.Helpers
{
    public interface ITimerLogicHelper
    {
        TimeSpan calcTimeLeftUntilEvent();
        void OnTimedEvent(object sender, ElapsedEventArgs e);
        Task<TimeSpan> CleanUpCurrentChallengeOnTimeElapsed(IChallengeFacadeApiClient challengeFacadeApiClient);
    }
}