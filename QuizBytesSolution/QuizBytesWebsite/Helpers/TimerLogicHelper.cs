using System.Timers;

namespace QuizBytesWebsite.Helpers
{
    public class TimerLogicHelper : ITimerLogicHelper
    {

        private TimeSpan day = new TimeSpan(24, 00, 00);    // 24 hours in a day.
        private TimeSpan now = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));     // The current time in 24 hour format
        private TimeSpan activationTime = new TimeSpan(13, 56, 00); // the time of day to fire the event

        private System.Timers.Timer _timer = new System.Timers.Timer();

        public TimeSpan calcTime()
        {
            TimeSpan timeLeftUntilFirstRun = day - now + activationTime;

            if (timeLeftUntilFirstRun.TotalHours > 24)
            {
                timeLeftUntilFirstRun -= new TimeSpan(24, 0, 0);
            }

            return timeLeftUntilFirstRun;
        }

        public void SetUpTimer()
        {

            _timer.Interval = calcTime().TotalMilliseconds;

            // Hook up the Elapsed event for the timer. 
            _timer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            _timer.AutoReset = true;

            // Start the timer
            _timer.Enabled = true;

        }

        public void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            // stuff that happens when the event fires
            Console.WriteLine("test");
        }
    }
}
