namespace BussinesObjects
{
    public interface IQuestionPool
    {
        IEnumerable<IQuestion> AllQuestions { get; set; }
    }
}