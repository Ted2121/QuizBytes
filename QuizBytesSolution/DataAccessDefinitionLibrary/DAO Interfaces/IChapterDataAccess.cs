using DataAccessDefinitionLibrary.DAO_models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface IChapterDataAccess
    {
        Task<Chapter> InsertChapterAsync(Chapter chapter);
        Task<Chapter> GetChapterByIdAsync(int chapterId);
        Task<Chapter> GetChapterByNameAsync(string chapterName);
        Task<IEnumerable<Chapter>> GetAllChaptersAsync();
        Task<IEnumerable<Chapter>> GetAllChaptersBySubjectAsync(Subject subject);
        Task UpdateChapterAsync(Chapter chapter);
        Task DeleteChapterAsync(Chapter chapter);
    }
}
