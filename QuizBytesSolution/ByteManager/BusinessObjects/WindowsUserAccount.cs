using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteManager.BussinesObjects
{
    public class WindowsUserAccount : IAccount
    {
        public string Password { get; set; }
        public string UserName { get; set; }

        
    }
}
