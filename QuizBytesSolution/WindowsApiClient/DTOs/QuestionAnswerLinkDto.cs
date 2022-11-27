using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApiClient.DTOs
{
    public class QuestionAnswerLinkDto
    {
        public QuestionDto Question { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
    }
}
