using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApiClient.DTOs
{
    public class QuizDto
    {
        public IEnumerable<QuestionAnswerLinkDto> QuizQuestions { get; set; }
    }
}
