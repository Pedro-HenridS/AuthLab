

using AuthLab.Domain.Interfaces.Users;

namespace AuthLab.Application.Services.Account
{
    public class PasswordHasherService
    {
        private ISearchUser _passwordHashService;

        public PasswordHasherService(ISearchUser passwordHashService)
        {
            _passwordHashService = passwordHashService;
        }

        public string Execute(string password)
        {
            return _passwordHashService.PasswordHasher(password);
        }
    }
}
