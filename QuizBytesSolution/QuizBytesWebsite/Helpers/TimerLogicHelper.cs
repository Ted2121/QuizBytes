using NUnit.Framework.Internal;
using System;
using System.Timers;
using WebApiClient;

namespace QuizBytesWebsite.Helpers
{
    public class TimerLogicHelper : ITimerLogicHelper
    {

        private ILeaderboardBuilder LeaderboardBuilder { get; set; }

        public TimerLogicHelper(ILeaderboardBuilder leaderboardBuilder)
        {
            LeaderboardBuilder = leaderboardBuilder;
        }

        private TimeSpan now = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"));
        // The current time in 24 hour format
        private TimeSpan day = new TimeSpan(24, 00, 00);    // 24 hours in a day.
        private System.Timers.Timer _timer = new System.Timers.Timer();
        // the time of day to fire the event
        private TimeSpan activationTime = new TimeSpan(14, 00, 00);

        #region TESTING ONLY keep commented
        // Adding 5 seconds to current time to be able to test cleaning up after the previous challenge and starting a new one
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

        public TimeSpan CalcTimeLeftUntilEvent()
        {
            TimeSpan timeLeftUntilFirstRun = day - now + activationTime;

            if (timeLeftUntilFirstRun.TotalHours > 24)
            {
                timeLeftUntilFirstRun -= new TimeSpan(24, 0, 0);
            }

            return timeLeftUntilFirstRun;
        }

        // injecting the rest client in this method because injecting in the constructor would require AddTransient due to using SignalR
        public async Task<TimeSpan> CleanUpCurrentChallengeOnTimeElapsed(IChallengeFacadeApiClient challengeFacadeApiClient)
        {
            _timer.Enabled = true;
            var timeSpan = CalcTimeLeftUntilEvent();
            var oneSecondLeft = new TimeSpan(0, 0, 1);

            _timer.AutoReset = true;

            // Start the timer
            if (timeSpan <= oneSecondLeft)
            {
                try
                {
                    await challengeFacadeApiClient.DistributeRewardsAsync(LeaderboardBuilder.BuildLeaderboardFromParticipantList());
                    await challengeFacadeApiClient.ClearTempTableBeforeNextChallengeAsync();
                    // Once the rewards are distributed and the current challenge table has been cleared, we start a new challenge
                    LeaderboardBuilder.InitializeChallenge();
                }
                catch
                {
                    _timer.Stop();
                    return new TimeSpan(0, 0, 0);

                }
            }

            return timeSpan;
        }

    }
}
