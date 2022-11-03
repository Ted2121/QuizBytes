using Dapper;
using DataAccessDefinitionLibrary;
using DataAccessDefinitionLibrary.DAO_Interfaces;
using DataAccessDefinitionLibrary.Data_Access_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SQLAccessImplementationLibrary
{
    public class QuestionDataAccess : BaseDataAccess, IQuestionDataAccess
    {
        public QuestionDataAccess(string connectionstring) : base(connectionstring)
        {
        }

        public async Task DeleteQuestionAsync(Question question)
        {
            string commandText = "DELETE FROM Question WHERE PKQuestionId = @PKQuestionId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    PKQuestionId = question.PKQuestionId
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to delete a row from Quesiton table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            string commandText = "SELECT* FROM Question";
            using (SqlConnection connection = CreateConnection())
            {
                try
                {
                    var questions = await connection.QueryAsync<Question>(commandText);

                    return questions;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Question table. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<Question> GetQuestionByIdAsync(int questionId)
        {
            string commandText = "SELECT * FROM Question WHERE PKQuestionId = @PKQuestionId";
            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    PKQuestionId = questionId
                };

                try
                {
                    var question = await connection.QuerySingleOrDefaultAsync<Question>(commandText, parameters);

                    return question;
                }
                catch (Exception ex)
                {

                    throw new($"Exception while trying to find the Question with the '{questionId}'. The exception was: '{ex.Message}'", ex);
                }

            }
        }

        public async Task<Question> InsertQuestionAsync(Question question)
        {
            string commandText = "INSERT INTO Question (FKChapterId, QuestionText, Hint) VALUES (@FKChapterId, @QuestionText, @Hint); SELECT CAST(scope_identity() AS int)";
            using (SqlConnection connection = CreateConnection())
            {

                var parameters = new
                {
                    FKChapterId = question.FKChapterId,
                    QuestionText = question.QuestionText,
                    Hint = question.Hint,
                };


                try
                {
                    await connection.ExecuteAsync(commandText, parameters);
                    question.PKQuestionId = (int)await connection.ExecuteScalarAsync(commandText, parameters);
                    return question;
                }
                catch (Exception ex)
                {

                    throw new($"Exception while trying to insert a Question object. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            string commandText = "UPDATE Question " +
                "FKChapterId = @FKChapterId, " +
                "QuestionText = @QuestionText, " +
                "Hint = @Hint " +
                "WHERE PKQuestionId = @PKQuestionId";

            using (SqlConnection connection = CreateConnection())
            {
                var parameters = new
                {
                    FKChapterId = question.FKChapterId,
                    QuestionText = question.QuestionText,
                    Hint = question.Hint,
                    PKQuestionId = question.PKQuestionId
                };

                try
                {
                    await connection.ExecuteAsync(commandText, parameters);

                }
                catch (Exception ex)
                {

                    throw new Exception($"Exception while trying to update a Question. The exception was: '{ex.Message}'", ex);
                }
            }
        }

        public async Task<IEnumerable<Question>> GetQuestionsByChapterAsync(Chapter chapter)
        {
            string commandText = "SELECT * FROM Question WHERE FKChapterId = @FKChapterId";
            using (SqlConnection connection = CreateConnection())
            {

                try
                {
                    var parameters = new
                    {
                        FKChapterId = chapter.PKChapterId
                    };

                    var questions = await connection.QueryAsync<Question>(commandText, parameters);

                    return questions;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Question table with the foreign key attribute: FKChapterId = {chapter.PKChapterId}. The exception was: '{ex.Message}'", ex);
                }
            }
        }


    }
}
