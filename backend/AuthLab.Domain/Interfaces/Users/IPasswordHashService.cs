

namespace AuthLab.Domain.Interfaces.Users
{
    public interface IPasswordHashService
    {
        string PasswordHasher(string password);

    }
}
