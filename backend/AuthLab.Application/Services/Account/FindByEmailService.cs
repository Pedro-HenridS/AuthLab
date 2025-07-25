

using AuthLab.Domain.Interfaces.Users;

namespace AuthLab.Application.Services.Account
{
    public class FindByEmailService
    {
        private IUserFindByEmailRepository _repository;

        public FindByEmailService(IUserFindByEmailRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Execute(string email)
        {
            return _repository.FindByEmail(email);
        }
    }
}
