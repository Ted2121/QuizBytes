using DataAccessLibrary.Data_Access_Models;
using DataAccessLibrary.Data_Access_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data_Access_Interfaces
{
    public interface IChapterDataAccess
    {
        void Insert(ChapterModel chapter);
        ChapterModel GetById(int id);
        IEnumerable<ChapterModel> GetAllChapters();
        IEnumerable<ChapterModel> GetAllChaptersBySubject(SubjectModel subject);
        bool UpdateChapter(ChapterModel chapter);
        bool DeleteChapter(ChapterModel chapter);
    }
}
