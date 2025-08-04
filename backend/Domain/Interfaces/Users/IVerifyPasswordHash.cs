

namespace Domain.Interfaces.Users
{
    public interface IVerifyPasswordHash
    {
        bool Verify(string password, string hash);
    }
}
