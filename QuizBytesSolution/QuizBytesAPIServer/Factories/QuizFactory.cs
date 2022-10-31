using QuizBytesAPIServer.DTOs;

namespace QuizBytesAPIServer.Factories
{
    public static class QuizFactory
    {
        public static QuizDto GetQuizDto(string quizType, CourseDto course)
        {
            int numberOfQuestions;
            
            switch (quizType.ToLower())
            {
                case "classic":
                
                    numberOfQuestions = 8;

                return new QuizDto()
                case "challenge":
                    break;
                    default: throw new ArgumentException();

            }
        }
    }
}
