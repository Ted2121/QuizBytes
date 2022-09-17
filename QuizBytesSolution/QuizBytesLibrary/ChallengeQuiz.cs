using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObjects
{
    public class ChallengeQuiz : IQuiz
    {
        const int maxNumberOfQuestions = 16;

        public int MaxNumberOfQuestions
        {
            get { return maxNumberOfQuestions; }
            
        }



    }
}
