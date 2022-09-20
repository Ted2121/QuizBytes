using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteManager.BussinesObjects
{
    public class TrueFalseQuestion : IQuestion
    {
        public int? Id { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        // This list is used just for polymorphism purposes - let's us write methods with an IQuestion parameter
        public List<string> WrongAnswers { get; set; }
        public string Hint { get; set; }
        public int? PointValue { get; set; }

        // I commented this out because we might not need it as we might be able to use just the list
        // public string WrongAnswer { get; set; }



    }
}
