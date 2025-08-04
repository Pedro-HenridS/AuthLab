

using Domain.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Security
{
    public class VerifyPasswordHash : IVerifyPasswordHash
    {

        public bool Verify(string password, string hash)
        {

            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
