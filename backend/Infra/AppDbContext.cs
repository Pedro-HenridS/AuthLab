using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    
    public class AppDbContext : DbContext
    
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users"); 
        }

        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
