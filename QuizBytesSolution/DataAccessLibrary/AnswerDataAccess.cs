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

        public async Task<bool> DeleteAnswerAsync(int answerId)
        {
            string commandText = "DELETE FROM Answer WHERE PKAnswerId = @PKAnswerId";
            try
            {
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        PKAnswerId = answerId
                    };
                    return await connection.ExecuteAsync(commandText, parameters) > 0;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to delete a row from Answer table. The exception was: '{ex.Message}'", ex);
            }
        }


        public async Task<IEnumerable<Answer>> GetAllAnswersAsync()
        {
            try
            {
                string commandText = "SELECT * FROM Answer";
                using (SqlConnection connection = CreateConnection())
                {
                    var answers = await connection.QueryAsync<Answer>(commandText);

                    return answers;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to read all rows from the Answer table. The exception was: '{ex.Message}'", ex);
            }
        }


        public async Task<IEnumerable<Answer>> GetAllAnswersByQuestionIdAsync(int questionId)
        {
            try
            {
                string commandText = "SELECT * FROM QuestionAnswer WHERE FKQuestionId = @FKQuestionId";
                using (SqlConnection connection = CreateConnection())
                {
                    var parameters = new
                    {
                        FKQuestionId = questionId
                    };

                    var answers = await connection.QueryAsync<Answer>(commandText, parameters);

                    return answers;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to read all Answers related to QuestionId: {questionId}. The exception was: '{ex.Message}'", ex);
            }
        }


        public async Task<Answer> InsertAnswerAsync(Answer answer)
        {
            try
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

                    await connection.ExecuteAsync(commandText, parameters);
                    answer.PKAnswerId = (int)await connection.ExecuteScalarAsync(commandText, parameters);
                    return answer;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to insert an Answer object. The exception was: '{ex.Message}'", ex);
            }
        }



        public async Task<bool> UpdateAnswerAsync(Answer answer)
        {
            try
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

                    return await connection.ExecuteAsync(commandText, parameters) > 0;

                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Exception while trying to update Answer. The exception was: '{ex.Message}'", ex);
            }
        }

    }
}
