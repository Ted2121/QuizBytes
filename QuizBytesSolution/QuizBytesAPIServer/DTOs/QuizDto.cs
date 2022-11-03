namespace QuizBytesAPIServer.DTOs
{
    public class QuizDto
    {

        // 8 quiz questions for normal quizzes and 16 for challenge quizzes
        public IEnumerable<QuestionAnswerLinkDto> QuizQuestions { get; set; }
        public bool IsInChallenge { get; set; }
        public int NumberOfQuestions { get; set; }

        public QuizDto(IEnumerable<QuestionAnswerLinkDto> quizQuestions, bool isInChallenge, int numberOfQuestions)
        {
            QuizQuestions = quizQuestions;
            IsInChallenge = isInChallenge;
            NumberOfQuestions = numberOfQuestions;
        }
       

    }
}
