using OtServer.Domain.Enums;

namespace OtServer.Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Access { get; set; }
        public int AccountNumber { get; set; }
        public int Vocation { get; set; }
        public int Cid { get; set; }
        public int Health { get; set; }
        public int HealthMax { get; set; }
        public int Soul { get; set; }
        public int SoulMax { get; set; }
        public int Direction { get; set; }
        public int LookBody { get; set; }
        public int LookFeet { get; set; }
        public int LookHead { get; set; }
        public int LookLegs { get; set; }
        public int LookType { get; set; }
        public int LookAddons { get; set; }
        public int KnowAddons { get; set; }

        public int Mana { get; set; }
        public int ManaMax { get; set; }
        public long ManaSpent { get; set; }
        public string MasterPos { get; set; }
        public string Pos { get; set; }
        public int Speed { get; set; }
        public int Cap { get; set; }
        public int MaxDepotItems { get; set; }
        public int Food { get; set; }
        public int Level { get; set; }
        public long Experience { get; set; }
        public int MagicLevel { get; set; }
        public SexEnum Sex { get; set; }
        public int GuildId { get; set; }
        public string GuildRank { get; set; }
        public string GuildNick { get; set; }
        public int OwnGuild { get; set; }
        public long LastLogin { get; set; }
        public long LastIP { get; set; }
        public int Save { get; set; }
        public long RedSkulltime { get; set; }
        public long RedSkull { get; set; }
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
