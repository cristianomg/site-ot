using Microsoft.EntityFrameworkCore;
using OtServer.Domain.Entities;
using OtServer.Domain.Enums;
using OtServer.Domain.Repositories;

namespace OtServer.Infrasctruture.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {

        private readonly DataContext _context;
        public PlayerRepository(DataContext context)
        {
            _context = context;
        }

        public List<Player> GetPlayerRankLevel()
        {
            var query = 
                FilterAccountManager(_context.Set<Player>())

                .OrderByDescending(x => x.Resets)
                .ThenByDescending(x=>x.Vocation)
                .ThenByDescending(x => x.Level)
                .ThenByDescending(x => x.Experience)
                .AsNoTracking();


            return query
                .ToList();
        }

        public List<Player> GetPlayerRankMagicLevel()
        {
            var query =
                FilterAccountManager(_context.Set<Player>())
                .OrderByDescending(x => x.MagicLevel)
                .ThenByDescending(x => x.ManaSpent);

            return query.ToList();

                
        }

        public List<Skill> GetPlayerRankSkill(SkillEnum skillId)
        {
            var query =
                _context.Set<Skill>()
                .Where(x => x.Id == (int)skillId)
                .Include(x => x.Player)
                .OrderByDescending(x=>x.SkillLevel)
                .ThenByDescending(x=>x.Tries);

            return query.ToList();
        }

        public Player? GetByName(string name)
        {
            var query = _context.Set<Player>().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            return query;
        }

        public List<DeathList> GetDeathLists()
        {
            var query = _context.Set<DeathList>()
                .OrderByDescending(x => x.Date)
                .Include(x=>x.Player)
                .Take(20);

            return query.ToList();
        }

        public List<DeathList> GetDeathByName(string playerName)
        {
            var query = _context.Set<DeathList>()
                .Where(x=>x.Player.Name == playerName)
                .OrderByDescending(x => x.Date)
                .Include(x => x.Player)
                .Take(5);

            return query.ToList();
        }

        public IEnumerable<Player?> GetPlayersOnline()
        {
            foreach(var p in GetOnlineList())
            {
                yield return GetByName(p);
            }
        }

        public List<string> GetOnlineList()
        {
            var onlinePlayers = new List<string>();
            var filePath = @"C:\Users\crist\OneDrive\Documentos\programacao\otserver\evolution078ots\data\logs\online.php";

            try
            {
                if (File.Exists(filePath))
                {
                    var content = File.ReadAllText(filePath);
                    
                    // Procura pelo padrão "Players online: " seguido dos nomes
                    if (content.Contains("Players online:"))
                    {
                        var startIndex = content.IndexOf("Players online:") + "Players online:".Length;
                        var endIndex = content.IndexOf(". Total:");
                        
                        if (endIndex > startIndex)
                        {
                            var playersString = content.Substring(startIndex, endIndex - startIndex).Trim();
                            
                            // Divide a string pelos nomes separados por vírgula
                            var players = playersString.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                                     .Select(p => p.Trim())
                                                     .Where(p => !string.IsNullOrEmpty(p))
                                                     .ToList();
                            
                            onlinePlayers.AddRange(players);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log do erro (você pode implementar um sistema de logging se necessário)
                Console.WriteLine($"Erro ao ler arquivo online.php: {ex.Message}");
            }

            return onlinePlayers;
        }

        private IQueryable<Player> FilterAccountManager(IQueryable<Player> query)
        {
            query =
                query
                .Where(x => x.Name != "Account Manager")
                .Where(x => x.Access < 2);

            return query;

        }

    }
}
