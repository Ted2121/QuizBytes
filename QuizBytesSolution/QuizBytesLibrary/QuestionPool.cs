using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObjects
{

    public class QuestionPool : IQuestionPool
    {
        // This QuestionPool IEnumerable will be used to pull all the questions from the Database
        // We use IEnumerable to only load in memory the questions we need when we need them
        public IEnumerable<IQuestion> AllQuestions { get; set; }

    }
}
