using QuizBytesAPIServer.DTOs;

namespace QuizBytesAPIServer.Factories
{
    public class QuizFactory
    {
        public QuestionAnswerLinkFactory QuestionAnswerLinkFactory { get; set; }
        public QuizFactory(QuestionAnswerLinkFactory questionAnswerLinkFactory)
        {
            QuestionAnswerLinkFactory = questionAnswerLinkFactory;
        }
        public static QuizDto GetQuizDto(string quizType, CourseDto course)
        {
            int numberOfQuestions;
            
            
            switch (quizType.ToLower())
            {
                case "classic":
                
                    numberOfQuestions = 8;
                    List<QuestionAnswerLinkDto> questionsInQuiz = new List<QuestionAnswerLinkDto>();
                    
                    return new QuizDto();
                case "challenge":
                    break;
                    default: throw new ArgumentException();

            }
        }

        private static IEnumerable<QuestionAnswerLinkDto> GetQuestions(int numberOfQuestions)
        {
            IEnumerable<QuestionAnswerLinkDto> questions = new List<QuestionAnswerLinkDto>();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                questions.Add()
            }

        }

        private static IEnumerable<QuestionAnswerLinkDto> GetAllQuestionsFromCourse(CourseDto course)
        {

        }
    }
}
