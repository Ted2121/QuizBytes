namespace DataAccessDefinitionLibrary.Data_Access_Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // one to many: chapter - subject
        public int FKSubjectId { get; set; }
        public Subject Subject { get; set; }
        // many to many with webusers
        public IEnumerable<WebUserChapterUnlock> WebUserChapterUnlocks { get; set; }
        public const int UnlockPrice = 50;

        // This constructor is for insertion with identity constraint
        public Chapter(string name, string description, int fKSubjectId)
        {
            Name = name;
            Description = description;
            FKSubjectId = fKSubjectId;
        }

        public Chapter()
        {
        }
    }
}
