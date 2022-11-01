using DataAccessDefinitionLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface IAnswerDataAccess
    {

        Task<Answer> InsertAnswerAsync(Answer answer);
        Task<Answer> UpdateAnswerAsync(Answer answer);
        Task<Answer> GetAnswersByQuestionIdAsync(int questionID);
        Task<IEnumerable<Answer>> GetAllAnswersAsync();
        Task<Answer> DeleteAnswerAsync();
    }
}
