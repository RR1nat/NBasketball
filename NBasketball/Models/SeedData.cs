using Microsoft.EntityFrameworkCore;

namespace NBasketball.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (!context.Teams.Any())
                {
                    context.Teams.AddRange(
                        // Лига NBA
                        new Team { Name = "Los Angeles Lakers", League = "NBA" },
                        new Team { Name = "Golden State Warriors", League = "NBA" },
                        new Team { Name = "Chicago Bulls", League = "NBA" },
                        new Team { Name = "Boston Celtics", League = "NBA" },
                        new Team { Name = "Miami Heat", League = "NBA" },
                        // Лига ACB
                        new Team { Name = "Real Madrid", League = "ACB" },
                        new Team { Name = "FC Barcelona", League = "ACB" },
                        new Team { Name = "Baskonia", League = "ACB" },
                        new Team { Name = "Valencia Basket", League = "ACB" },
                        // Лига Евролига
                        new Team { Name = "CSKA Moscow", League = "EuroLeague" },
                        new Team { Name = "Anadolu Efes", League = "EuroLeague" },
                        new Team { Name = "Fenerbahçe", League = "EuroLeague" },
                        new Team { Name = "Olympiacos", League = "EuroLeague" },
                        // Новые лиги для пагинации
                        new Team { Name = "Panathinaikos", League = "Greek League" },
                        new Team { Name = "Maccabi Tel Aviv", League = "Israeli League" },
                        new Team { Name = "Virtus Bologna", League = "Italian League" }
                    );
                    context.SaveChanges();
                }

                if (!context.Players.Any())
                {
                    context.Players.AddRange(
                        // Игроки для NBA
                        new Player { Name = "Леброн Джеймс", Position = "Форвард", TeamId = 1, ImagePath = "/assets/lebron.jpg", DateAdded = DateTime.Parse("2024-04-01") },
                        new Player { Name = "Кавай Ленард", Position = "Нападающий", TeamId = 1, ImagePath = "/assets/kavai.jpg", DateAdded = DateTime.Parse("2024-04-24") },
                        new Player { Name = "Пол Джордж", Position = "Нападающий", TeamId = 1, ImagePath = "/assets/pol.jpg", DateAdded = DateTime.Parse("2024-04-26") },
                        new Player { Name = "Джимми Батлер", Position = "Нападающий", TeamId = 3, ImagePath = "/assets/batler.jpg", DateAdded = DateTime.Parse("2024-04-28") },
                        new Player { Name = "Стефен Карри", Position = "Защитник", TeamId = 2, ImagePath = "/assets/steph.jpg", DateAdded = DateTime.Parse("2024-04-05") },
                        new Player { Name = "Кевин Дюрант", Position = "Форвард", TeamId = 3, ImagePath = "/assets/kevin.jpg", DateAdded = DateTime.Parse("2024-04-10") },
                        new Player { Name = "Яннис Адетокунбо", Position = "Форвард", TeamId = 2, ImagePath = "/assets/yanis.jpg", DateAdded = DateTime.Parse("2024-04-12") },
                        new Player { Name = "Никола Йокич", Position = "Центровой", TeamId = 3, ImagePath = "/assets/nikola.jpg", DateAdded = DateTime.Parse("2024-04-15") },
                        // Игроки для ACB
                        new Player { Name = "Серхио Льюль", Position = "Защитник", TeamId = 6, ImagePath = "/assets/llull.jpg", DateAdded = DateTime.Parse("2024-04-18") },
                        new Player { Name = "Никола Миротич", Position = "Форвард", TeamId = 7, ImagePath = "/assets/mirotic.jpg", DateAdded = DateTime.Parse("2024-04-20") },
                        new Player { Name = "Томас Саторански", Position = "Защитник", TeamId = 7, ImagePath = "/assets/satoransky.jpg", DateAdded = DateTime.Parse("2024-04-22") },
                        new Player { Name = "Марсельиньо Уэртас", Position = "Защитник", TeamId = 8, ImagePath = "/assets/huertas.jpg", DateAdded = DateTime.Parse("2024-04-23") },
                        // Игроки для Евролиги
                        new Player { Name = "Нандо Де Коло", Position = "Защитник", TeamId = 10, ImagePath = "/assets/decolo.jpg", DateAdded = DateTime.Parse("2024-04-25") },
                        new Player { Name = "Василие Мицич", Position = "Защитник", TeamId = 11, ImagePath = "/assets/micic.jpg", DateAdded = DateTime.Parse("2024-04-26") },
                        new Player { Name = "Ян Веселы", Position = "Центровой", TeamId = 12, ImagePath = "/assets/vesely.jpg", DateAdded = DateTime.Parse("2024-04-27") },
                        new Player { Name = "Костас Слукас", Position = "Защитник", TeamId = 13, ImagePath = "/assets/sloukas.jpg", DateAdded = DateTime.Parse("2024-04-28") }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}