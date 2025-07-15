using OtServer.Domain.Entities;
using OtServer.Domain.Enums;

namespace OtServer.Domain.Repositories
{
    public interface IPlayerRepository
    {
        List<Player> GetPlayerRankLevel();
        List<Player> GetPlayerRankMagicLevel();
        List<Skill> GetPlayerRankSkill(SkillEnum skillId);
        Player? GetByName(string name);
        bool IsPlayer(string playerName);
        Player? GetById(int id);
    }
}
