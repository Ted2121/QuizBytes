using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObjects
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

        public SingleAnswerQuestion(int id, string questionText, string correctAnswer, List<string> wrongAnswers, string wrongAnswerOne, string wrongAnswerTwo, string wrongAnswerThree)
        {
            Id = id;
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            WrongAnswers = wrongAnswers;
            WrongAnswerOne = wrongAnswerOne;
            WrongAnswerTwo = wrongAnswerTwo;
            WrongAnswerThree = wrongAnswerThree;
        }

        public SingleAnswerQuestion(string questionText, string correctAnswer, List<string> wrongAnswers, string wrongAnswerOne, string wrongAnswerTwo, string wrongAnswerThree)
        {
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            WrongAnswers = wrongAnswers;
            WrongAnswerOne = wrongAnswerOne;
            WrongAnswerTwo = wrongAnswerTwo;
            WrongAnswerThree = wrongAnswerThree;
        }

        public SingleAnswerQuestion(string questionText, string correctAnswer, List<string> wrongAnswers)
        {
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            WrongAnswers = wrongAnswers;
        }

        public SingleAnswerQuestion(int id, string questionText, string correctAnswer, List<string> wrongAnswers)
        {
            Id = id;
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            WrongAnswers = wrongAnswers;
        }
    }
}
