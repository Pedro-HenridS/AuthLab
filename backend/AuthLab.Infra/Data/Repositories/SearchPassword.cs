
using AuthLab.Domain.Interfaces.Users;

namespace AuthLab.Infra.Data.Repositories
{
    public class SearchPassword : ISearchPassword
    {
        public Task<bool> SearchPasswordHash(string email, string passwordhash) 
        { 
        }
    }
}
