
using Microsoft.EntityFrameworkCore;

namespace GameManagement.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().Property(g => g.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Game>().Property(g => g.UpdatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
