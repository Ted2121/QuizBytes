using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteManager.BussinesObjects
{
    public class SingleAnswerQuestion : IQuestion
    {
        public int? Id { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> WrongAnswers { get; set; }
        public string WrongAnswerOne { get; set; }
        public string WrongAnswerTwo { get; set; }
        public string WrongAnswerThree { get; set; }
        public string Hint { get; set; }
        public int? PointValue { get; set; }

        

        
        
    }
}
