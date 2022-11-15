using System.Timers;

namespace QuizBytesWebsite.Helpers
{
    public interface ITimerLogicHelper
    {
        TimeSpan calcTime();
        void OnTimedEvent(object sender, ElapsedEventArgs e);
        void SetUpTimer();
    }
}