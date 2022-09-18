using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObjects
{
    public class WindowsUserAccount : IAccount
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        
    }
}
