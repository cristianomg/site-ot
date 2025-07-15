using OtServer.Domain.Entities;

namespace OtServer.Domain.Repositories
{
    public interface IDeathListRepository
    {
        List<DeathList> GetLast20();
        List<DeathList> GetByPlayerName(string playerName);
    }
}
