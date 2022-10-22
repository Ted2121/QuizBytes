using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteManager.BussinesObjects
{
    public class WebsiteUserAccount
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int TotalPoints { get; set; }
        public int AvailablePoints { get; set; }
        // TODO add logic in the BusinessLogic layer that unlocks the first chapter of each subject automatically and adds it to this list
        public IEnumerable<Chapter> UnlockedChapters { get; set; }
   



    }
}
