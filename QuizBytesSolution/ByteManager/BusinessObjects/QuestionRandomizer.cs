using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteManager.BussinesObjects
{
        //TODO This needs to be moved to Webserver's Controller layer and be tested
    public static class QuestionRandomizer
    {
        public static IEnumerable<IQuestion> RandomizeQuestions(IEnumerable<IQuestion> questions)
        {
           // A GUID is a global unique identifier.
           // We will use it to get 8 questions from a question pool without getting the same question twice
             return questions.OrderBy(a => Guid.NewGuid()).ToList(); 
            
            
        }

    }
}
