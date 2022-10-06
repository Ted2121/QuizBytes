using DataAccessDefinitionLibrary.DAO_models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface IChapterDataAccess
    {
        Task<ChapterModel> InsertAsync(ChapterModel chapter);
        Task<ChapterModel> GetByIdAsync(int chapterId);
        Task<IEnumerable<ChapterModel>> GetAllChaptersAsync();
        Task<IEnumerable<ChapterModel>> GetAllChaptersBySubjectAsync(SubjectModel subject);
        Task UpdateChapterAsync(ChapterModel chapter);
        Task DeleteChapterAsync(ChapterModel chapter);
    }
}
