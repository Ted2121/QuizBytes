namespace DataAccessDefinitionLibrary.Data_Access_Models
{
    public class Chapter
    {
        public int PKChapterId { get; set; }
        public string Name { get; set; }
        public int FKSubjectId { get; set; }
        public string Description { get; set; }
        
        // one to many: chapter - subject
        // public Subject Subject { get; set; }
        // many to many: chapter - webusers
        // public IEnumerable<WebUserChapterUnlock> WebUserChapterUnlocks { get; set; }

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
