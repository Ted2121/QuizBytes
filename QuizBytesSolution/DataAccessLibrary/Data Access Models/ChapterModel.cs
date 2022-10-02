using DataAccessLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data_Access_Objects
{
    public class ChapterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // one to many: chapter - subject
        public int SubjectId { get; set; }
        public SubjectModel Subject { get; set; }
        // many to many with webusers
        public IEnumerable<WebUserChapterUnlocks> WebUserChapterUnlocks { get; set; }
    }
}
