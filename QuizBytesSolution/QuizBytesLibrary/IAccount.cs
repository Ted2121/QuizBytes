namespace BussinesObjects
{
    public interface IAccount
    {
        int Id { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
    }
}