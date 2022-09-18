using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObjects
{
    public class WebsiteUserAccount : IAccount
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int TotalPoints { get; set; }
        public int PointsInWallet { get; set; }

        
    }
}
