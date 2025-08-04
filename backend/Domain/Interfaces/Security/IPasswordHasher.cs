namespace Domain.Interfaces.Security
{
    public interface IPasswordHasher
    {
        string PasswordHasher(string passwordhash);
    }
}
