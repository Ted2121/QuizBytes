using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObjects
{
        //TODO This needs to be moved to BusinessLogic layer and be tested
    public static class QuestionRandomizer
    {
        public static IEnumerable<IQuestion> RandomizeQuestions(IEnumerable<IQuestion> questions)
        {
           
             return questions.OrderBy(a => Guid.NewGuid()).ToList(); 
            
            
        }

    }
}
