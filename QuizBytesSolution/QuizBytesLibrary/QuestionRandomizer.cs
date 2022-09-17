using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObjects
{
    public static class QuestionRandomizer
    {
        
        public static IEnumerable<IQuestion> RandomizeQuestions(IEnumerable<IQuestion> questions)
        {
           
             return questions.OrderBy(a => Guid.NewGuid()).ToList(); 
            
            
        }

    }
}
