namespace BussinesObjects
{
    public interface INormalQuiz : IQuiz
    {
        //TODO interface must be moved and adapted to business logic layer
        List<IQuestion> GetRandomQuestionsFromChapter(Chapter chapter);
    }
}