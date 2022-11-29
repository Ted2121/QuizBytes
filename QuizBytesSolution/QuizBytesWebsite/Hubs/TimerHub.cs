using Microsoft.AspNetCore.SignalR;
using QuizBytesWebsite.Helpers;
using WebApiClient;

namespace QuizBytesWebsite.Hubs
{
    public class TimerHub : Hub
    {
        private ITimerLogicHelper TimerLogicHelper { get; set; }
        private IChallengeFacadeApiClient ChallengeFacadeApiClient { get; set; }
        public TimerHub(ITimerLogicHelper timerLogicHelper, IChallengeFacadeApiClient challengeFacadeApiClient)
        {
            TimerLogicHelper = timerLogicHelper;
            ChallengeFacadeApiClient = challengeFacadeApiClient;
        }

        public async Task PrintTime()
        {
            var timeSpan = await TimerLogicHelper.CleanUpCurrentChallengeOnTimeElapsed(ChallengeFacadeApiClient);
            await Clients.All.SendAsync("DisplayTime", timeSpan.ToString(@"hh\:mm\:ss"));
        }
    }
}
