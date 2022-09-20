using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteManager.BussinesObjects
{
    public class NormalQuiz : IQuiz
    {
        // fullprop was needed here as this will be a constant - we will always have 8 questions in a normal quiz
        const int maxNumberOfQuestions = 8;
        public int MaxNumberOfQuestions
        {
            get { return maxNumberOfQuestions; }

        }
    }

        //TODO move to business logic
        //public List<IQuestion> GetRandomQuestionsFromChapter(Chapter chapter)
        //{
        //    return RandomizeQuestions(GetAllQuestionsFromAChapter(chapter)).Take(8);
        //    throw new NotImplementedException();
        //}

    
}
