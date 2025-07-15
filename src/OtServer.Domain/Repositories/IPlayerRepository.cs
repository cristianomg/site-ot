using OtServer.Domain.Entities;
using OtServer.Domain.Enums;

namespace OtServer.Domain.Repositories
{
    public interface IPlayerRepository
    {
        List<Player> GetPlayerRankLevel();
        List<Player> GetPlayerRankMagicLevel();
        List<Skill> GetPlayerRankSkill(SkillEnum skillId);
        List<DeathList> GetDeathLists();
        List<DeathList> GetDeathByName(string playerName);
        Player? GetByName(string name);
        IEnumerable<Player?> GetPlayersOnline();
        List<string> GetOnlineList();
    }
}
