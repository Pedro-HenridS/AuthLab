
using AuthLab.Domain.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace AuthLab.Infra.Data.Repositories
{
    public class FindByEmailRepository : IUserFindByEmailRepository
    {
        private AppDbContext _context;
        public FindByEmailRepository(AppDbContext context) 
        { 
            _context = context;
        }  

        public async Task<bool> FindByEmail(string email)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if(result is null)
            {
                return false;
            }
            return true;
        }

    }
}
