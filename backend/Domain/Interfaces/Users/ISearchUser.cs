

namespace Domain.Interfaces.Users
{
    public interface ISearchUser
    {
        string SearchUserByEmail(string email, string password);
    }
}
