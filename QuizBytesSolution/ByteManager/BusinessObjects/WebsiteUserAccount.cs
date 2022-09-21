using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteManager.BussinesObjects
{
    public class WebsiteUserAccount : IWebsiteUserAccount
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int TotalPoints { get; set; }
        public int PointsInWallet { get; set; }
        // TODO add logic in the BusinessLogic layer that unlocks the first chapter of each subject automatically and adds it to this list
        public IEnumerable<Chapter> UnlockedChapters { get; set; }
        // Do not put the challenge score in a constructor - this property will only be initialized if the user participates in a challenge and then it will be replaced the next time a user participates



    }
}
