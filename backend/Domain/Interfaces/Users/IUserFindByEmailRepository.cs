

namespace Domain.Interfaces.Users
{
    public interface IUserFindByEmailRepository
    {
        public Task<bool> FindByEmail(string email);
    }
}
