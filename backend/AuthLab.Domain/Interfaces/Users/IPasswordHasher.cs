

namespace Domain.Interfaces.Users
{
    public interface IPasswordHasher
    {
        string PasswordHasher(string passwordhash);
    }
}
