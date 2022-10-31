namespace QuizBytesAPIServer.DTOs
{
    public class QuizDto
    {
        
        // 8 quiz questions for normal quizzes and 16 for challenge quizzes
        public IEnumerable<QuestionAnswerLinkDto> QuizQuestions { get; set; }
        // if false, NumberOfQuestions will be 8 (normal quiz) else, 16 (challenge quiz)
        public bool IsInChallenge { get; set; }
        public int NumberOfQuestions { get; set; }

    }
}
