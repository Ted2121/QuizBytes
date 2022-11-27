using System;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApiClient.DTOs;

namespace WindowsApiClient
{
    public interface IChapterFacadeApiClient
    {
        Task<IEnumerable<ChapterDto>> GetAllChaptersAsync();
        Task<IEnumerable<ChapterDto>> GetAllChaptersBySubjectAsync(SubjectDto subject);
        Task<ChapterDto> GetChapterByIdAsync(int id);
        Task<bool> DeleteChapterAsync(int id);
        Task<int> InsertChapterAsync(ChapterDto chapter);
        Task<bool> UpdateChapterAsync(ChapterDto chapter);

    }
}
