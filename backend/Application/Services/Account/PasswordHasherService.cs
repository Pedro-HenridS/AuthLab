using Domain.Interfaces.Security;

namespace Application.Services.Account
{
    public class PasswordHasherService
    {
        private IPasswordHasher _passwordHashService;

        public PasswordHasherService(IPasswordHasher passwordHashService)
        {
            _passwordHashService = passwordHashService;
        }

        public string Execute(string password)
        {
            return _passwordHashService.PasswordHasher(password);
        }
    }
}
