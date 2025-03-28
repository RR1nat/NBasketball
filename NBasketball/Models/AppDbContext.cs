using Microsoft.EntityFrameworkCore;

namespace NBasketball.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Связь Player -> Team
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players) // Указываем обратную связь
                .HasForeignKey(p => p.TeamId);

            // Связь Favorite -> Player
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Player)
                .WithMany() // У игрока нет обратной коллекции Favorites
                .HasForeignKey(f => f.PlayerId);
        }
    }
}