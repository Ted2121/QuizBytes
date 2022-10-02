using DataAccessLibrary.Data_Access_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data_Access_Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        public CourseModel Course { get; set; }
        public IEnumerable<ChapterModel> Chapters { get; set; }
    }
}
