using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string? QuestionText { get; set; }
        public string? Hint { get; set; }
        public int ChapterId { get; set; }
    }
}
