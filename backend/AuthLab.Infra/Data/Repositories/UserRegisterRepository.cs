using Domain.Interfaces.Users;
using Domain.Repositories;


namespace Infra.Data.Repositories
{
    public class UserRegisterRepository : IUserRegisterRepository
    {
        private AppDbContext _context { get; set; }

        public UserRegisterRepository(AppDbContext context)
        {   
            _context = context;
        }

        public async Task CreateAsync(User user) 
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(true);

        }
    }
}
