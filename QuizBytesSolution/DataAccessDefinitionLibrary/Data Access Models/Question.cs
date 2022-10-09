using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDefinitionLibrary.DAO_models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Hint { get; set; }
        public int FKChapterId { get; set; }
    }
}
