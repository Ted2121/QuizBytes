using System.Timers;
using WebApiClient;

namespace QuizBytesWebsite.Helpers
{
    public class TimerLogicHelper : ITimerLogicHelper
    {
        // private ChallengeFacadeApiClient ChallengeFacadeApiClient { get; set; }

        //public TimerLogicHelper(ChallengeFacadeApiClient challengeFacadeApiClient)
        //{
        //    ChallengeFacadeApiClient = challengeFacadeApiClient;
        //}

        private TimeSpan now = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));     
        // The current time in 24 hour format
        private TimeSpan day = new TimeSpan(24, 00, 00);    // 24 hours in a day.
        private System.Timers.Timer _timer = new System.Timers.Timer();
        // the time of day to fire the event
        private TimeSpan activationTime = new TimeSpan(12, 54, 00);

        #region TESTING ONLY - adding 5 seconds to current time to be able to test starting the quiz
        //private static int _timeInstance;

        //private TimeSpan activationTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, GetTimeInstance() + 5);

        //public static int GetTimeInstance()
        //{
        //    if (_timeInstance == 0)
        //    {
        //        _timeInstance = DateTime.Now.Second;
        //    }
        //    return _timeInstance;
        //}
        #endregion

        public TimeSpan calcTimeLeftUntilEvent()
        {
            TimeSpan timeLeftUntilFirstRun = day - now + activationTime;

            if (timeLeftUntilFirstRun.TotalHours > 24)
            {
                timeLeftUntilFirstRun -= new TimeSpan(24, 0, 0);
            }

            return timeLeftUntilFirstRun;
        }

        public async Task<TimeSpan> CleanUpCurrentChallengeOnTimeElapsed(IChallengeFacadeApiClient challengeFacadeApiClient)
        {
            _timer.Enabled = true;
            var timeSpan = calcTimeLeftUntilEvent();
            var zeroSeconds = new TimeSpan(0, 0, 1);

            //// Have the timer fire repeated events (true is the default)
            _timer.AutoReset = true;

            //TODO remove console logging
            // Start the timer
            if(timeSpan == zeroSeconds)
            {
                try
                {
                await challengeFacadeApiClient.ClearTempTableBeforeNextChallengeAsync();

                }
                catch
                {
                    _timer.Stop();
                    Console.WriteLine("could not clean up");
                    return new TimeSpan(0, 0, 0);

                }
                Console.WriteLine("cleaned up");
            }

            return timeSpan;
        }

        public void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
        }
    }
}
