﻿using DataAccessDefinitionLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDefinitionLibrary.DAO_Interfaces;

public interface IAnswerDataAccess
{

    Task<int> InsertAnswerAsync(Answer answer);
    Task<bool> UpdateAnswerAsync(Answer answer);
    Task<IEnumerable<Answer>> GetAllAnswersByQuestionIdAsync(int id);
    Task<IEnumerable<Answer>> GetAllAnswersAsync();
    Task<bool> DeleteAnswerAsync(int id);
}
