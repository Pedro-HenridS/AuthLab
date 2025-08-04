using Domain.Interfaces.Security;

namespace Infra.Data.Security
{
    public class BCryptPasswordHasher : IPasswordHasher
    {
        public string PasswordHasher(string password) 
        { 
            string hash = BCrypt.Net.BCrypt.HashPassword(password);
            return hash;
        }
    }
}
