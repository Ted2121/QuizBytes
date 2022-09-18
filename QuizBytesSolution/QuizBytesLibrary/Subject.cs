using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObjects
{
    public class Subject
    {
        public string Name { get; set; }
        public IEnumerable<Chapter> Chapters { get; set; }
    }
}
