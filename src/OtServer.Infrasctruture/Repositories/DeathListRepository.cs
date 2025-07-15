using Microsoft.EntityFrameworkCore;
using OtServer.Domain.Entities;
using OtServer.Domain.Repositories;

namespace OtServer.Infrasctruture.Repositories
{
    public class DeathListRepository : IDeathListRepository
    {
        private readonly DataContext _dataContext;

        public DeathListRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<DeathList> GetByPlayerName(string playerName)
        {
            var query = _dataContext.Set<DeathList>()
                .Include(x=>x.Player)
                .Where(x=> x.Player.Name.ToLower() == playerName.ToLower())
                .Take(5);

            return query.ToList();
        }

        public List<DeathList> GetLast20()
        {
            var query = _dataContext.Set<DeathList>()
                .Include(x => x.Player)
                .Take(20);

            return query.ToList();
        }
    }
}
