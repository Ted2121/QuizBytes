﻿using DataAccessDefinitionLibrary.Data_Access_Models;
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
        Task UpdateAnswerAsync(Answer answer);
        Task<IEnumerable<Answer>> GetAllAnswersByQuestionIdAsync(int questionId);
        Task<IEnumerable<Answer>> GetAllAnswersAsync();
        Task DeleteAnswerAsync(int answerId);
    }
}
