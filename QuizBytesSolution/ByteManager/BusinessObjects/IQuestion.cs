namespace ByteManager.BussinesObjects
{
    public interface IQuestion
    {
        int? Id { get; set; }
        string QuestionText { get; set; }
        string CorrectAnswer { get; set; }
        IEnumerable<string> WrongAnswers { get; set; }
        string Hint { get; set; }
        int? PointValue { get; set; }
    }
}