using OtServer.Domain.Enums;

namespace OtServer.Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountNumber { get; set; }
        public VocationEnum Vocation { get; set; }
        public int Health { get; set; }
        public int HealthMax { get; set; }
        public int Mana { get; set; }
        public int ManaMax { get; set; }
        public int Level { get; set; }
        public long Experience { get; set; }
        public int MagicLevel { get; set; }
        public SexEnum Sex { get; set; }
        public int GuildId { get; set; }
        public string GuildRank { get; set; }
        public string Comment { get; set; }
        public bool Hide { get; set; }
        public int Resets { get; set; }
        public int PvpKills { get; set; }
        public int PvpDeaths { get; set; }
        public virtual List<Skill> Skills { get; set; }
        public virtual Guild Guild { get; set; }
        public virtual Account Account { get; set; }
    }
}
