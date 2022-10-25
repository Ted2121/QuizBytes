namespace QuizBytesAPIServer.DTOs
{
    public class QuizDto
    {
        public int QuizId { get; set; }
        // 8 quiz questions for normal quizzes and 16 for challenge quizzes
        public IEnumerable<QuestionAnswerLinkDto> QuizQuestions { get; set; }
        // if false, NumberOfQuestions will be 8 (normal quiz) else, 16 (challenge quiz)
        public bool IsInChallenge { get; set; }
        public int NumberOfQuestions { get; set; }

        // TODO logic should be in a factory method
        //public QuizDto(int quizId, IEnumerable<QuestionAnswerLinkDto> quizQuestions, bool isInChallenge = false)
        //{
        //    QuizId = quizId;
        //    QuizQuestions = quizQuestions;
        //    IsInChallenge = isInChallenge;
        //    NumberOfQuestions = IsInChallenge == false ? 8 : 16;
        //}
    }
}
