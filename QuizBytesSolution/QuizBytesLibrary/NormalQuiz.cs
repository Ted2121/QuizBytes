using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObjects
{
    public class NormalQuiz : IQuiz
    {
        const int maxNumberOfQuestions = 8;
        public int MaxNumberOfQuestions { get; }
    }

        //TODO move to business logic
        //public List<IQuestion> GetRandomQuestionsFromChapter(Chapter chapter)
        //{
        //    return RandomizeQuestions(GetAllQuestionsFromAChapter(chapter)).Take(8);
        //    throw new NotImplementedException();
        //}

    
}
