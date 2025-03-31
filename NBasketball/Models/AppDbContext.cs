using Microsoft.EntityFrameworkCore;
using NBasketball.Models;

namespace NBasketball.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка первичных ключей
            modelBuilder.Entity<Team>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Player>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Favorite>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            // Связь Player -> Team
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь Favorite -> Player
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Player)
                .WithMany()
                .HasForeignKey(f => f.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Настройка столбца DateAdded с значением по умолчанию
            modelBuilder.Entity<Player>()
                .Property(p => p.DateAdded)
                .HasColumnName("date_added")
                .HasDefaultValueSql("DATE");

            // Начальное заполнение данными для Teams
            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "Los Angeles Lakers", League = "NBA" },
                new Team { Id = 2, Name = "Golden State Warriors", League = "NBA" },
                new Team { Id = 3, Name = "Chicago Bulls", League = "NBA" },
                new Team { Id = 4, Name = "Boston Celtics", League = "NBA" },
                new Team { Id = 5, Name = "Miami Heat", League = "NBA" },
                new Team { Id = 6, Name = "Real Madrid", League = "ACB" },
                new Team { Id = 7, Name = "FC Barcelona", League = "ACB" },
                new Team { Id = 8, Name = "Baskonia", League = "ACB" },
                new Team { Id = 9, Name = "Valencia Basket", League = "ACB" },
                new Team { Id = 10, Name = "CSKA Moscow", League = "EuroLeague" },
                new Team { Id = 11, Name = "Anadolu Efes", League = "EuroLeague" },
                new Team { Id = 12, Name = "Fenerbahçe", League = "EuroLeague" },
                new Team { Id = 13, Name = "Olympiacos", League = "EuroLeague" },
                new Team { Id = 14, Name = "Panathinaikos", League = "Greek League" },
                new Team { Id = 15, Name = "Maccabi Tel Aviv", League = "Israeli League" },
                new Team { Id = 16, Name = "Virtus Bologna", League = "Italian League" }
            );

            // Начальное заполнение данными для Players
            modelBuilder.Entity<Player>().HasData(
                // Игроки для NBA
                new Player
                {
                    Id = 1,
                    Name = "Леброн Джеймс",
                    Position = "Форвард",
                    TeamId = 1,
                    ImagePath = "/assets/lebron.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-01"), DateTimeKind.Utc)
                },
                new Player
                {
                    Id = 2,
                    Name = "Кавай Ленард",
                    Position = "Нападающий",
                    TeamId = 1,
                    ImagePath = "/assets/kavai.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-24"), DateTimeKind.Utc)
                },
                new Player
                {
                    Id = 3,
                    Name = "Пол Джордж",
                    Position = "Нападающий",
                    TeamId = 1,
                    ImagePath = "/assets/pol.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-26"), DateTimeKind.Utc)
                },
                new Player
                {
                    Id = 4,
                    Name = "Джимми Батлер",
                    Position = "Нападающий",
                    TeamId = 3,
                    ImagePath = "/assets/batler.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-28"), DateTimeKind.Utc)
                },
                new Player
                {
                    Id = 5,
                    Name = "Стефен Карри",
                    Position = "Защитник",
                    TeamId = 2,
                    ImagePath = "/assets/steph.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-05"), DateTimeKind.Utc)
                },
                new Player
                {
                    Id = 6,
                    Name = "Кевин Дюрант",
                    Position = "Форвард",
                    TeamId = 3,
                    ImagePath = "/assets/kevin.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-10"), DateTimeKind.Utc)
                },
                new Player
                {
                    Id = 7,
                    Name = "Яннис Адетокунбо",
                    Position = "Форвард",
                    TeamId = 2,
                    ImagePath = "/assets/yanis.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-12"), DateTimeKind.Utc)
                },
                new Player
                {
                    Id = 8,
                    Name = "Никола Йокич",
                    Position = "Центровой",
                    TeamId = 3,
                    ImagePath = "/assets/nikola.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-15"), DateTimeKind.Utc)
                },
                // Игроки для ACB
                new Player
                {
                    Id = 9,
                    Name = "Серхио Льюль",
                    Position = "Защитник",
                    TeamId = 6,
                    ImagePath = "/assets/llull.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-18"), DateTimeKind.Utc)
                },
                new Player
                {
                    Id = 10,
                    Name = "Никола Миротич",
                    Position = "Форвард",
                    TeamId = 7,
                    ImagePath = "/assets/mirotic.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-20"), DateTimeKind.Utc)
                },
                new Player
                {
                    Id = 11,
                    Name = "Томас Саторански",
                    Position = "Защитник",
                    TeamId = 7,
                    ImagePath = "/assets/satoransky.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-22"), DateTimeKind.Utc)
                },
                new Player
                {
                    Id = 12,
                    Name = "Марсельиньо Уэртас",
                    Position = "Защитник",
                    TeamId = 8,
                    ImagePath = "/assets/huertas.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-23"), DateTimeKind.Utc)
                },
                // Игроки для Евролиги
                new Player
                {
                    Id = 13,
                    Name = "Нандо Де Коло",
                    Position = "Защитник",
                    TeamId = 10,
                    ImagePath = "/assets/decolo.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-25"), DateTimeKind.Utc)
                },
                new Player
                {
                    Id = 14,
                    Name = "Василие Мицич",
                    Position = "Защитник",
                    TeamId = 11,
                    ImagePath = "/assets/micic.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-26"), DateTimeKind.Utc)
                },
                new Player
                {
                    Id = 15,
                    Name = "Ян Веселы",
                    Position = "Центровой",
                    TeamId = 12,
                    ImagePath = "/assets/vesely.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-27"), DateTimeKind.Utc)
                },
                new Player
                {
                    Id = 16,
                    Name = "Костас Слукас",
                    Position = "Защитник",
                    TeamId = 13,
                    ImagePath = "/assets/sloukas.jpg",
                    DateAdded = DateTime.SpecifyKind(DateTime.Parse("2024-04-28"), DateTimeKind.Utc)
                }
            );
        }
    }
}