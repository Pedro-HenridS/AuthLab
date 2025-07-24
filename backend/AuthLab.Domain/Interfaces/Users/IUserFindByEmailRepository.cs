
using Microsoft.AspNetCore.Mvc;

namespace AuthLab.Domain.Interfaces.Users
{
    public interface IUserFindByEmailRepository
    {
        public Task FindByEmail(string email);
    }
}
