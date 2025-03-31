using Microsoft.AspNetCore.Mvc;
using NBasketball.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NBasketball.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Favorites()
        {
            return View();
        }

        public IActionResult Teams()
        {
            return View();
        }

        public IActionResult Players(string position, string team)
        {
            ViewBag.Teams = _context.Teams.ToList();
            var players = _context.Players.AsQueryable();
            if (position != "all" && !string.IsNullOrEmpty(position))
            {
                players = players.Where(p => p.Position == position);
            }
            if (team != "all" && !string.IsNullOrEmpty(team))
            {
                players = players.Where(p => p.Team.Name == team);
            }
            return View(players.ToList());
        }

        [HttpGet]
        public IActionResult AddPlayer()
        {
            try
            {
                // Временно убираем загрузку команд
                ViewBag.Teams = new List<Team>(); // Пустой список, чтобы представление не ломалось

                var model = new Player();
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddPlayer: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayer(Player player, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Teams = _context.Teams.ToList();
                return View(player);
            }

            if (imageFile != null)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                player.ImagePath = $"/assets/{fileName}";
            }

            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return RedirectToAction("Players");
        }


        [HttpGet]
        public IActionResult GetTeamsByLeague(string league)
        {
            var teams = _context.Teams
                .Where(t => t.League == league)
                .Select(t => new { name = t.Name, url = $"/teams/{t.Name.ToLower().Replace(" ", "-")}.html" })
                .ToList();
            return Json(teams);
        }

        [HttpGet]
        public IActionResult SearchLeagues(string searchTerm)
        {
            var leagues = _context.Teams
                .GroupBy(t => t.League)
                .Select(g => new
                {
                    name = g.Key,
                    displayName = g.Key == "NBA" ? "Национальная Баскетбольная Ассоциация (NBA)" :
                                  g.Key == "ACB" ? "Лига ACB" :
                                  g.Key == "EuroLeague" ? "Евролига" :
                                  g.Key == "Greek League" ? "Греческая Лига" :
                                  g.Key == "Israeli League" ? "Израильская Лига" : "Итальянская Лига"
                })
                .Where(l => string.IsNullOrEmpty(searchTerm) ||
                           l.name.ToLower().Contains(searchTerm.ToLower()) ||
                           l.displayName.ToLower().Contains(searchTerm.ToLower()))
                .OrderBy(l => l.name)
                .ToList();
            return Json(leagues);
        }

        [HttpGet]
        public IActionResult GetLeagueDetails(string leagueName)
        {
            var league = _context.Teams
                .Where(t => t.League == leagueName)
                .GroupBy(t => t.League)
                .Select(g => new
                {
                    name = g.Key,
                    displayName = g.Key == "NBA" ? "Национальная Баскетбольная Ассоциация (NBA)" :
                                  g.Key == "ACB" ? "Лига ACB" :
                                  g.Key == "EuroLeague" ? "Евролига" :
                                  g.Key == "Greek League" ? "Греческая Лига" :
                                  g.Key == "Israeli League" ? "Израильская Лига" : "Итальянская Лига",
                    description = g.Key == "NBA" ? "Национальная баскетбольная ассоциация..." :
                                  g.Key == "ACB" ? "Лига ACB (Asociación de Clubs...)" :
                                  g.Key == "EuroLeague" ? "Евролига — главная..." :
                                  g.Key == "Greek League" ? "Греческая баскетбольная лига..." :
                                  g.Key == "Israeli League" ? "Израильская баскетбольная лига..." : "Итальянская баскетбольная лига...",
                    teams = g.Select(t => new { name = t.Name, url = $"/teams/{t.Name.ToLower().Replace(" ", "-")}.html" }).ToList()
                })
                .FirstOrDefault();

            if (league == null)
            {
                return Json(new
                {
                    name = "",
                    displayName = "Лига не найдена",
                    description = "",
                    teams = new List<object>()
                });
            }

            return Json(league);
        }

        [HttpGet]
        public IActionResult GetAllLeagues()
        {
            var leagues = _context.Teams
                .GroupBy(t => t.League)
                .Where(g => g.Key == "NBA" || g.Key == "ACB" || g.Key == "EuroLeague")
                .Select(g => new
                {
                    name = g.Key,
                    displayName = g.Key == "NBA" ? "Национальная Баскетбольная Ассоциация (NBA)" :
                                  g.Key == "ACB" ? "Лига ACB" : "Евролига",
                    description = g.Key == "NBA" ? "Национальная баскетбольная ассоциация..." :
                                  g.Key == "ACB" ? "Лига ACB (Asociación de Clubs...)" : "Евролига — главная...",
                    teams = g.Select(t => new { name = t.Name, url = $"/teams/{t.Name.ToLower().Replace(" ", "-")}.html" }).ToList()
                })
                .OrderBy(l => l.name)
                .ToList();
            return Json(leagues);
        }

        [HttpGet]
        public IActionResult GetLeaguesPaginated(int page = 1, int pageSize = 3)
        {
            var leagues = _context.Teams
                .GroupBy(t => t.League)
                .Select(g => new
                {
                    name = g.Key,
                    displayName = g.Key == "NBA" ? "Национальная Баскетбольная Ассоциация (NBA)" :
                                  g.Key == "ACB" ? "Лига ACB" :
                                  g.Key == "EuroLeague" ? "Евролига" :
                                  g.Key == "Greek League" ? "Греческая Лига" :
                                  g.Key == "Israeli League" ? "Израильская Лига" : "Итальянская Лига",
                    description = g.Key == "NBA" ? "Национальная баскетбольная ассоциация..." :
                                  g.Key == "ACB" ? "Лига ACB (Asociación de Clubs...)" :
                                  g.Key == "EuroLeague" ? "Евролига — главная..." :
                                  g.Key == "Greek League" ? "Греческая баскетбольная лига..." :
                                  g.Key == "Israeli League" ? "Израильская баскетбольная лига..." : "Итальянская баскетбольная лига..."
                })
                .OrderBy(l => l.name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalLeagues = _context.Teams.Select(t => t.League).Distinct().Count();
            var hasMore = (page * pageSize) < totalLeagues;

            return Json(new { leagues = leagues, hasMore = hasMore });
        }

        [HttpGet]
        public IActionResult SearchTeams(string searchTerm)
        {
            return SearchLeagues(searchTerm);
        }

        [HttpGet]
        public async Task<IActionResult> FilterPlayers(string position, string team)
        {
            var players = _context.Players.AsQueryable();

            if (position != "all" && !string.IsNullOrEmpty(position))
                players = players.Where(p => p.Position == position);
            if (team != "all" && !string.IsNullOrEmpty(team))
                players = players.Where(p => p.Team.Name == team);

            var favoritePlayerIds = await _context.Favorites.Select(f => f.PlayerId).ToListAsync();

            var result = await players.Select(p => new
            {
                p.Id,
                p.Name,
                p.Position,
                TeamName = p.Team.Name,
                p.ImagePath,
                DateAdded = p.DateAdded.ToString("yyyy-MM-dd"),
                IsFavorite = favoritePlayerIds.Contains(p.Id)
            }).ToListAsync();

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleFavorite(int playerId)
        {
            if (!await _context.Players.AnyAsync(p => p.Id == playerId))
            {
                return Json(new { success = false, message = "Игрок не найден" });
            }

            var favoriteExists = await _context.Favorites.AnyAsync(f => f.PlayerId == playerId);

            if (!favoriteExists)
            {
                _context.Favorites.Add(new Favorite { PlayerId = playerId });
                await _context.SaveChangesAsync();
                Console.WriteLine($"Добавлена запись в Favorites для PlayerId: {playerId}");
                return Json(new
                {
                    success = true,
                    isFavorite = true,
                    message = "Игрок добавлен в избранное!"
                });
            }
            else
            {
                var favoritesToRemove = await _context.Favorites.Where(f => f.PlayerId == playerId).ToListAsync();
                _context.Favorites.RemoveRange(favoritesToRemove);
                await _context.SaveChangesAsync();
                Console.WriteLine($"Удалено {favoritesToRemove.Count} записей для PlayerId: {playerId}");
                return Json(new
                {
                    success = true,
                    isFavorite = false,
                    message = "Игрок удалён из избранного!"
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var favoritePlayerIds = await _context.Favorites.Select(f => f.PlayerId).ToListAsync();

            var players = await _context.Players
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Position,
                    TeamName = p.Team.Name,
                    p.ImagePath,
                    DateAdded = p.DateAdded.ToString("yyyy-MM-dd"),
                    IsFavorite = favoritePlayerIds.Contains(p.Id)
                })
                .ToListAsync();

            return Json(players);
        }

        [HttpGet]
        public async Task<IActionResult> FilterPlayersByTeam(string team)
        {
            var favoritePlayerIds = await _context.Favorites.Select(f => f.PlayerId).ToListAsync();

            var players = await _context.Players
                .Where(p => p.Team.Name == team || team == "all")
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Position,
                    TeamName = p.Team.Name,
                    p.ImagePath,
                    DateAdded = p.DateAdded.ToString("yyyy-MM-dd"),
                    IsFavorite = favoritePlayerIds.Contains(p.Id)
                })
                .ToListAsync();

            return Json(players);
        }

        [HttpGet]
        public async Task<IActionResult> FilterPlayersByPosition(string position)
        {
            var favoritePlayerIds = await _context.Favorites.Select(f => f.PlayerId).ToListAsync();

            var players = await _context.Players
                .Where(p => p.Position == position || position == "all")
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Position,
                    TeamName = p.Team.Name,
                    p.ImagePath,
                    DateAdded = p.DateAdded.ToString("yyyy-MM-dd"),
                    IsFavorite = favoritePlayerIds.Contains(p.Id)
                })
                .ToListAsync();

            return Json(players);
        }

        [HttpGet]
        public async Task<IActionResult> FilterPlayersMultiple(string position, string team, string name)
        {
            var players = _context.Players.AsQueryable();

            if (position != "all" && !string.IsNullOrEmpty(position))
                players = players.Where(p => p.Position == position);
            if (team != "all" && !string.IsNullOrEmpty(team))
                players = players.Where(p => p.Team.Name == team);
            if (!string.IsNullOrEmpty(name))
                players = players.Where(p => p.Name.ToLower().Contains(name.ToLower()));

            var favoritePlayerIds = await _context.Favorites.Select(f => f.PlayerId).ToListAsync();

            var result = await players.Select(p => new
            {
                p.Id,
                p.Name,
                p.Position,
                TeamName = p.Team.Name,
                p.ImagePath,
                DateAdded = p.DateAdded.ToString("yyyy-MM-dd"),
                IsFavorite = favoritePlayerIds.Contains(p.Id)
            }).ToListAsync();

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayerAjax(IFormFile imageFile)
        {
            // Логируем все полученные данные
            foreach (var key in Request.Form.Keys)
            {
                Console.WriteLine($"{key}: {Request.Form[key]}");
            }
            if (imageFile != null) Console.WriteLine($"ImageFile: {imageFile.FileName}, Size: {imageFile.Length}");

            // Ручная валидация
            var name = Request.Form["Name"].ToString();
            var position = Request.Form["Position"].ToString();
            var teamIdStr = Request.Form["TeamId"].ToString();
            var dateAddedStr = Request.Form["DateAdded"].ToString();

            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(name)) errors.Add("Имя обязательно");
            if (string.IsNullOrWhiteSpace(position)) errors.Add("Позиция обязательна");
            if (!int.TryParse(teamIdStr, out int teamId) || teamId <= 0) errors.Add("Команда обязательна");
            if (!DateTime.TryParseExact(dateAddedStr, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime dateAdded))
            {
                errors.Add("Неверный формат даты добавления. Ожидается формат ГГГГ-ММ-ДД (например, 2025-03-31).");
            }
            if (imageFile == null || imageFile.Length == 0) errors.Add("Фото игрока обязательно");

            if (errors.Any())
            {
                return Json(new { success = false, message = "Ошибка валидации", errors = errors });
            }

            try
            {
                // Проверка существования команды
                if (!await _context.Teams.AnyAsync(t => t.Id == teamId))
                {
                    return Json(new { success = false, message = "Указанная команда не найдена" });
                }

                // Создаём объект Player вручную
                var player = new Player
                {
                    Name = name,
                    Position = position,
                    TeamId = teamId,
                    DateAdded = dateAdded
                };

                // Обработка изображения
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                player.ImagePath = $"/assets/{fileName}";

                // Добавление в БД
                _context.Players.Add(player);
                await _context.SaveChangesAsync();

                // Получение данных команды для ответа
                var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == player.TeamId);
                var addedPlayer = new
                {
                    Id = player.Id,
                    Name = player.Name,
                    Position = player.Position,
                    TeamName = team?.Name ?? "Без команды",
                    ImagePath = player.ImagePath,
                    DateAdded = player.DateAdded.ToString("yyyy-MM-dd"),
                    IsFavorite = false
                };

                return Json(new { success = true, message = "Игрок успешно добавлен!", player = addedPlayer });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in AddPlayerAjax: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return Json(new { success = false, message = $"Ошибка при добавлении игрока: {ex.Message}" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFavoritePlayers()
        {
            var favoritePlayerIds = await _context.Favorites.Select(f => f.PlayerId).ToListAsync();

            var players = await _context.Players
                .Where(p => favoritePlayerIds.Contains(p.Id))
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Position,
                    TeamName = p.Team.Name,
                    p.ImagePath,
                    DateAdded = p.DateAdded.ToString("yyyy-MM-dd"),
                    IsFavorite = true // Все игроки в этом списке избранные
                })
                .ToListAsync();

            return Json(players);
        }
    }
}