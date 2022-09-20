namespace ByteManager.BussinesObjects
{
    public interface IQuizLogic
    {
        //TODO logic must be moved and adapted to business logic layer
        List<IQuestion> GetRandomQuestionsFromChapter(Chapter chapter);
    }
}