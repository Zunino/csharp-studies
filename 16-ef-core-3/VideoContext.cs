using Microsoft.EntityFrameworkCore;

namespace _16_ef_core_3
{
    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql("Host=localhost;Username=user;Password=pass;Port=5432;Database=postgres;");
            
    }
}