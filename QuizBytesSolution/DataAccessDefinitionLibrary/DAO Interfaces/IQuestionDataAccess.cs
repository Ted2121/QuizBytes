using DataAccessDefinitionLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface IQuestionDataAccess
    {
        Task<Question> InsertQuestionAsync(Question question);
        Task<Question> GetQuestionByIdAsync(int questionId);

        Task<IEnumerable<Question>> GetQuestionsByChapterAsync(int chapterId);
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task UpdateQuestionAsync(Question question);
        Task DeleteQuestionAsync(Question question);
    }
}
