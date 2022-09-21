using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteManager.BusinessObjects
{
    internal interface IWebsiteUserAcc
    {
        string Name { get; set; }
        string password { get; set; }
        string Email { get; set; }
        int totalPoints { get; set; }
    }
}
