using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObjects
{
    public class TrueFalseQuestion : IQuestion
    {
        public int? Id { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        // This list is used just for polymorphism purposes - let's us write methods with an IQuestion parameter
        public List<string> WrongAnswers { get; set; }
        // I commented this out because we might not need it as we might be able to use just the list
        // public string WrongAnswer { get; set; }

        public TrueFalseQuestion(int? id, string questionText, string correctAnswer, List<string> wrongAnswers) // ,string wrongAnswer)
        {
            Id = id;
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            WrongAnswers = wrongAnswers;
            // WrongAnswer = wrongAnswer;
        }

        public TrueFalseQuestion(string questionText, string correctAnswer, List<string> wrongAnswers) //, string wrongAnswer)
        {
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            WrongAnswers = wrongAnswers;
            //WrongAnswer = wrongAnswer;
        }

        //public TrueFalseQuestion(string questionText, string correctAnswer, string wrongAnswer)
        //{
        //    QuestionText = questionText;
        //    CorrectAnswer = correctAnswer;
        //    WrongAnswer = wrongAnswer;
        //}

        //public TrueFalseQuestion(int id, string questionText, string correctAnswer, string wrongAnswer)
        //{
        //    Id = id;
        //    QuestionText = questionText;
        //    CorrectAnswer = correctAnswer;
        //    WrongAnswer = wrongAnswer;
        //}
    }
}
