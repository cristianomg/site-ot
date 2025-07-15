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
                .ThenByDescending(x => x.Level)
                .ThenByDescending(x=>x.Vocation)
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
                .Where(x => x.Player.Name != "Account Manager")
                .Where(x => x.Player.Access < 2)
                .OrderByDescending(x=>x.SkillLevel)
                .ThenByDescending(x=>x.Tries);

            return query.ToList();
        }

        public Player? GetByName(string name)
        {
            var query = _context.Set<Player>().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            return query;
        }

        private IQueryable<Player> FilterAccountManager(IQueryable<Player> query)
        {
            query =
                query
                .Where(x => x.Name != "Account Manager")
                .Where(x => x.Access < 2);

            return query;

        }

        public Player? GetById(int id)
        {
            var query = _context.Set<Player>().Find(id);

            return query;
        }

        public bool IsPlayer(string playerName)
        {
            return _context.Set<Player>().Any(x=>x.Name.ToLower() == playerName.ToLower());    
        }
    }
}
