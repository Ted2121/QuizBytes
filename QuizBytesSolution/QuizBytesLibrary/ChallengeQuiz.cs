using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObjects
{
    public class ChallengeQuiz : IQuiz
    {
        // fullprop was needed here as this will be a constant - we will always have 16 questions in a challenge quiz
        const int maxNumberOfQuestions = 16;

        public int MaxNumberOfQuestions
        {
            get { return maxNumberOfQuestions; }
            
        }



    }
}
