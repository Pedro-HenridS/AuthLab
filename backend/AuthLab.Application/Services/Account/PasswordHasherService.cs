

using AuthLab.Domain.Interfaces.Users;

namespace AuthLab.Application.Services.Account
{
    public class PasswordHasherService
    {
        private IPasswordHashService _passwordHashService;

        public PasswordHasherService(IPasswordHashService passwordHashService)
        {
            _passwordHashService = passwordHashService;
        }

        public string Execute(string password)
        {
            return _passwordHashService.PasswordHasher(password);
        }
    }
}
