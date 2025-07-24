using AuthLab.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuthLab.Infra
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options) { }
            
        public DbSet<User> Users { get; set; }
    }
}
