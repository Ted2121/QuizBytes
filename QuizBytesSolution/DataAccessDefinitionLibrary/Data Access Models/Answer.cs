using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDefinitionLibrary.DAO_models
{
    public class Answer
    {
        public int Id { get; set; }
        public string IsCorrect { get; set; }
        public string AnswerText { get; set; }
        public int FKQuestionId { get; set; }

        public Answer()
        {

        }
    }
}
