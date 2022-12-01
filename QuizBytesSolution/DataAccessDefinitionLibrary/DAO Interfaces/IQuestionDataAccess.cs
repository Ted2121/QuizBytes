using DataAccessDefinitionLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDefinitionLibrary.DAO_Interfaces;

public interface IQuestionDataAccess
{
    Task<int> InsertQuestionAsync(Question question);
    Task<Question> GetQuestionByIdAsync(int id);

    Task<IEnumerable<Question>> GetQuestionsByChapterAsync(Chapter chapter);
    Task<IEnumerable<Question>> GetAllQuestionsAsync();
    Task<bool> UpdateQuestionAsync(Question question);
    Task<bool> DeleteQuestionAsync(int id);
}
