

using Domain.Interfaces.Users;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class GetUser: IGetUser
    {
        private readonly AppDbContext _context;

        public GetUser(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {   
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
