

using Domain.Entities;

namespace Domain.Interfaces.Users
{   
    public interface IGetUser
    {
        Task<User> GetUserByEmail(string email); 
    }
}
