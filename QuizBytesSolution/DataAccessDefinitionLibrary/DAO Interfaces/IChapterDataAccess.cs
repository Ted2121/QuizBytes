using DataAccessDefinitionLibrary.DAO_models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface IChapterDataAccess
    {
        Task<ChapterModel> InsertAsync(ChapterModel chapter);
        Task<ChapterModel> GetByIdAsync(int id);
        Task<IEnumerable<ChapterModel>> GetAllChaptersAsync();
        Task<IEnumerable<ChapterModel>> GetAllChaptersBySubjectAsync(SubjectModel subject);
        Task<bool> UpdateChapterAsync(ChapterModel chapter);
        Task<bool> DeleteChapterAsync(ChapterModel chapter);
    }
}
