namespace DataAccessDefinitionLibrary.DAO_models
{
    public class ChapterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // one to many: chapter - subject
        public int FKSubjectId { get; set; }
        public SubjectModel Subject { get; set; }
        // many to many with webusers
        public IEnumerable<WebUserChapterUnlocks> WebUserChapterUnlocks { get; set; }


        // This constructor is for insertion with identity constraint
        public ChapterModel(string name, string description, int fKSubjectId)
        {
            Name = name;
            Description = description;
            FKSubjectId = fKSubjectId;
        }


    }
}
