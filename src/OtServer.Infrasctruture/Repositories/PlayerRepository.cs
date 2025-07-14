using Microsoft.EntityFrameworkCore;
using OtServer.Domain.Entities;
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

        public List<Player> GetPlayerRank()
        {
            var query = _context.Set<Player>().OrderByDescending(x => x.Resets).ThenByDescending(x => x.Level).ThenByDescending(x => x.Experience).AsNoTracking():


            return query
                .ToList();
        }
    }
}
