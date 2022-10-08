using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDefinitionLibrary.Data_Access_Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public string IsCorrect { get; set; }
        public string AnswerText { get; set; }
        public int FKQuestionId { get; set; }
    }
}
