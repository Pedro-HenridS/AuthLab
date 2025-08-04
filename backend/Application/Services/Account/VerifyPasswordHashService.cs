


using Application.Services.UserServices;
using Domain.Interfaces.Users;

namespace Application.Services.Account
{
    public class VerifyPasswordHashService
    {
        private IVerifyPasswordHash _repository;
        private IGetUser _getUser;

        public VerifyPasswordHashService(
            IVerifyPasswordHash repository,
            IGetUser getUser)
        {
            _repository = repository;
            _getUser = getUser;
        }

        public async Task<bool> Execute(string password, string email)
        {
            var user = await _getUser.GetUserByEmail(email);
            var hash = user.Password;
            return _repository.Verify(password, hash);
        }
    }
}
