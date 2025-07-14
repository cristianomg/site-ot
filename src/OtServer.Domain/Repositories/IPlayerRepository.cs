using OtServer.Domain.Entities;

namespace OtServer.Domain.Repositories
{
    public interface IPlayerRepository
    {
        List<Player> GetPlayerRank();
    }
}
