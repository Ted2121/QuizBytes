using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;

namespace SQLAccessImplementationLibrary
{
    public class AnswerDataAccess : BaseDataAccess , IAnswerDataAccess
    {
        public AnswerDataAccess(string connectionstring) : base(connectionstring)
        {
        }

        public async Task DeleteAnswerAsync(Answer answer)
        {
            string commandText = "DELETE FROM Answer WHERE AnswerText = @AnswerText";
            using(SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    AnswerText = answer.AnswerText
                };
                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }

                catch(Exception ex)
                {
                    throw new Exception($"Exception while trying to delete a row from Answer table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<Answer>> GetAllAnswersAsync()
        {
            string commandText = "SELECT * FROM Answer";
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    var answers = await connection.QueryAsync<Answer>(commandText);

                    return answers;
                }
                catch(Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Answer table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<Answer>> GetAllAnswersByQuestionIdAsync(int questionId)
        {
            string commandText = "SELECT * FROM QuestionAnswer WHERE FKQuestionId = @FKQuestionId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    FKQuestionId = questionId
                };
                try
                {
                    var answers = await connection.QueryAsync<Answer>(commandText, parameters);

                    return answers;
                }
                catch(Exception ex)
                {
                    throw new Exception($"Exception while trying to read all Answers related to QuestionId: {questionId}. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task InsertAnswerAsync(Answer answer)
        {
            string commandText = "INSERT INTO QuestionAnswer(FKQuestionId, AnswerText, IsCorrect) VALUES (@FKQuestionId, @AnswerText, @IsCorrect)";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    FKQuestionId = answer.FKQuestionId,
                    AnswerText = answer.AnswerText,
                    IsCorrect = answer.IsCorrect
                };
                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }
                catch(Exception ex)
                {
                    throw new Exception($"Exception while trying to insert an Answer object. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        // TODO this is a problem. We need to add a PK to be able to update 1 row
        public async Task UpdateAnswerAsync(Answer answer)
        {
            string commandText = "UPDATE Answer " +
                "AnswerText = @AnswerText " +
                "IsCorrect = @IsCorrect" +
                "WHERE FKQuestionId = @FKQuestionId";
            using(SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    AnswerText = answer.AnswerText,
                    IsCorrect = answer.IsCorrect,
                    FKQuestionId = answer.FKQuestionId
                };
                try
                {
                    await connection.ExecuteAsync(commandText, parameters);

                }
                catch(Exception ex)
                {
                    throw new Exception($"Exception while trying to update Answer. The exception was: '{ex.Message}'", ex);
                }
            }
        }
    }
}
