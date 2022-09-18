namespace BussinesObjects
{
    public interface IQuestionPool
    {
        IEnumerable<IQuestion> Questions { get; set; }
    }
}