using Domain.Entities;

namespace Domain.Interfaces.Users
{
    public interface IUserRegisterRepository
    {
        Task CreateAsync(User user);
    }
}
