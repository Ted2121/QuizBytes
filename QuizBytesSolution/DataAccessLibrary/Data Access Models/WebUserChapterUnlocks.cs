using DataAccessLibrary.Data_Access_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data_Access_Models
{
    public class WebUserChapterUnlocks
    {
        public string WebUserUsername { get; set; }
        public int ChapterId { get; set; }
        public WebUserModel WebUser { get; set; }
        public ChapterModel Chapter { get; set; }
    }
}
