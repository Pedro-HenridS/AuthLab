using AuthLab.Domain.Interfaces.Users;

namespace AuthLab.Infra.Data.Security
{
    public class BCryptPasswordHasher : ISearchUser
    {
        public string PasswordHasher(string password) 
        { 
            string hash = BCrypt.Net.BCrypt.HashPassword(password);
            return hash;
        }
    }
}
