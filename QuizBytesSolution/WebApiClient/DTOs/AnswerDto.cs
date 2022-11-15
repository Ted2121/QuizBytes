using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.DTOs
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string IsCorrect { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
    }
}
