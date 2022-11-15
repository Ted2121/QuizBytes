using Microsoft.AspNetCore.SignalR;
using QuizBytesWebsite.Helpers;

namespace QuizBytesWebsite.Hubs
{
    public class TimerHub : Hub
    {
        public ITimerLogicHelper TimerLogicHelper { get; set; }
        public TimerHub(ITimerLogicHelper timerLogicHelper)
        {
            TimerLogicHelper = timerLogicHelper;
        }

        //TimerLogicHelper _timerLogicHelper = new TimerLogicHelper();
        public async Task PrintTime()
        {
            await Clients.All.SendAsync("DisplayTime", TimerLogicHelper.calcTime().ToString(@"hh\:mm\:ss"));
        }
    }
}
