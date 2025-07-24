using AuthLab.Domain.Repositories;

namespace AuthLab.Domain.Interfaces.Users
{
    public interface IUserRegisterRepository
    {
        Task CreateAsync(User user);
    }
}
