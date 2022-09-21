namespace ByteManager.BussinesObjects
{
    public interface IWebsiteUserAccount
    {
        string UserName { get; set; }
        string Password { get; set; }
        int PointsInWallet { get; set; }
        int TotalPoints { get; set; }
        IEnumerable<Chapter> UnlockedChapters { get; set; }
    }
}