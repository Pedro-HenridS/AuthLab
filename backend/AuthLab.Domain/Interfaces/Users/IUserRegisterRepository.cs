using Domain.Repositories;

namespace Domain.Interfaces.Users
{
    public interface IUserRegisterRepository
    {
        Task CreateAsync(User user);
    }
}
