using Dapper;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System.Data.SqlClient;

namespace SQLAccessImplementationLibrary
{
    public class AnswerDataAccess : BaseDataAccess, IAnswerDataAccess
    {
        public AnswerDataAccess(string connectionstring) : base(connectionstring)
        {
        }

        public async Task DeleteAnswerAsync(Answer answer)
        {
            string commandText = "DELETE FROM Answer WHERE PKAnswerId = @PKAnswerId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    PKAnswerId = answer.PKAnswerId
                };
                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }

                catch (Exception ex)
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
                catch (Exception ex)
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
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all Answers related to QuestionId: {questionId}. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<Answer> InsertAnswerAsync(Answer answer)
        {
            string commandText = "INSERT INTO QuestionAnswer(FKQuestionId, AnswerText, IsCorrect) VALUES (@FKQuestionId, @AnswerText, @IsCorrect); SELECT CAST(scope_identity() AS int)";
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
                    answer.PKAnswerId = (int)await connection.ExecuteScalarAsync(commandText, parameters);
                    return answer;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to insert an Answer object. The exception was: '{ex.Message}'", ex);
                }
            }
        }


        public async Task UpdateAnswerAsync(Answer answer)
        {
            string commandText = "UPDATE Answer " +
                "FKQuestionId = @FKQuestionId, " +
                "AnswerText = @AnswerText, " +
                "IsCorrect = @IsCorrect" +
                "WHERE PKAnswerId = @PKAnswerId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    FKQuestionId = answer.FKQuestionId,
                    AnswerText = answer.AnswerText,
                    IsCorrect = answer.IsCorrect,
                    PKAnswerId = answer.PKAnswerId
                };
                try
                {
                    await connection.ExecuteAsync(commandText, parameters);

                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to update Answer. The exception was: '{ex.Message}'", ex);
                }
            }
        }
    }
}
