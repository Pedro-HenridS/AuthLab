
namespace AuthLab.Domain.Interfaces.Users
{
    public interface ISearchPassword
    {
        Task<bool> SearchPasswordHash(string passwordhash);
    }
}
