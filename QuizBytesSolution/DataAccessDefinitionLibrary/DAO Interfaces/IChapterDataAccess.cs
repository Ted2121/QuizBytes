using DataAccessDefinitionLibrary.Data_Access_Models;


namespace DataAccessDefinitionLibrary.DAO_Interfaces;

public interface IChapterDataAccess
{
    Task<int> InsertChapterAsync(Chapter chapter);
    Task<Chapter> GetChapterByIdAsync(int chapterId);
    Task<Chapter> GetChapterByNameAsync(string chapterName);
    Task<IEnumerable<Chapter>> GetAllChaptersAsync();
    Task<IEnumerable<Chapter>> GetAllChaptersBySubjectAsync(Subject subject);
    Task<bool> UpdateChapterAsync(Chapter chapter);
    Task<bool> DeleteChapterAsync(int chapterId);
}
