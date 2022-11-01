using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDefinitionLibrary.Data_Access_Models
{
    public class Answer
    {
        public int FKQuestionId { get; set; }
        public string IsCorrect { get; set; }
        public string AnswerText { get; set; }

        public Answer()
        {

        }
    }
}
