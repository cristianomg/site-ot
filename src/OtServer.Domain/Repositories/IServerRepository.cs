using OtServer.Domain.Entities;

namespace OtServer.Domain.Repositories
{
    public interface IServerRepository
    {
        IEnumerable<Player?> GetPlayersOnline();
        bool GetServerStatus();
    }
}
