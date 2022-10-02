using DataAccessLibrary.Data_Access_Interfaces;
using DataAccessLibrary.Data_Access_Models;
using DataAccessLibrary.Data_Access_Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data_Access_Implementation
{
    public class ChapterDataAccess : IChapterDataAccess
    {
        public bool DeleteChapter(ChapterModel chapter)
        {
            
            string commandText = "DELETE FROM Chapters WHERE ChapterId = @chapterId";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@chapterId", chapter.Id);

                try
                {
                    return command.ExecuteNonQuery() == 1;
                    
                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to delete a row from Chapters table. The exception was: '{ex.Message}'", ex);
                }
            }
        
        }

        public IEnumerable<ChapterModel> GetAllChapters()
        {
           
            string commandText = "SELECT * FROM Chapters";
            using (SqlConnection connection = SQLConnectionFactory.GetSqlConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(commandText, connection);

                try
                {
                    List<ChapterModel> chapters = new List<ChapterModel>();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        chapters.Add(DataReaderRowToChapter(reader));
                    }
                    return chapters;

                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Chapters table. The exception was: '{ex.Message}'", ex);
                }
            }
        
        }

        //TODO
        public IEnumerable<ChapterModel> GetAllChaptersBySubject(SubjectModel subject)
        {
         
            string commandText = "SELECT * FROM Account WHERE ";
            using (SqlConnection connection = DBConnectionFactory.GetSqlConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand(commandText, connection);

                try
                {
                    List<Account> accounts = new List<Account>();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        accounts.Add(DataReaderRowToAccount(reader));
                    }
                    return accounts;

                }
                catch (Exception ex)
                {
                    throw new Exception($"Exception while trying to read all rows from the Account table. The exception was: '{ex.Message}'", ex);
                }
            }
        
        }

        public ChapterModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ChapterModel chapter)
        {
            throw new NotImplementedException();
        }

        public bool UpdateChapter(ChapterModel chapter)
        {
            throw new NotImplementedException();
        }
        private ChapterModel DataReaderRowToChapter(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

    }
}
