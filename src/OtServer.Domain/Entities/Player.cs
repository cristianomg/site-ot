using OtServer.Domain.Enums;

namespace OtServer.Domain.Entities
{
    public class Player
    {
        public Player()
        {
            
        }
        public Player(string name, SexEnum sex, int voc)
        {
            Name = name;
            Sex = sex;
            Level = 8;
            Vocation = voc;
            Access = 0;
            Health = 180;
            HealthMax = 180;
            Mana = 40;
            ManaMax = 40;
            SoulMax = 250;
            Experience = 4200;
            LookBody = 20;
            LookFeet = 30;
            LookHead = 40;
            LookLegs = 50;
            LookType = 128;
            Pos = "121;311;7";
            MasterPos = "121;311;7";
            Speed = 900;
            Cap = 380;

            Skills = new List<Skill>
            {
                new Skill
                {
                    PlayerId = this.Id,
                    Id = 0,
                    SkillLevel = 10,
                    Tries = 0
                },
                new Skill
                {
                    PlayerId = this.Id,
                    Id = 1,
                    SkillLevel = 10,
                    Tries = 0
                },
                new Skill
                {
                    PlayerId = this.Id,
                    Id = 2,
                    SkillLevel = 10,
                    Tries = 0
                },
                new Skill
                {
                    PlayerId = this.Id,
                    Id = 3,
                    SkillLevel = 10,
                    Tries = 0
                },
                new Skill
                {
                    PlayerId = this.Id,
                    Id = 4,
                    SkillLevel = 10,
                    Tries = 0
                },
                new Skill
                {
                    PlayerId = this.Id,
                    Id = 5,
                    SkillLevel = 10,
                    Tries = 0
                },
                new Skill
                {
                    PlayerId = this.Id,
                    Id = 6,
                    SkillLevel = 10,
                    Tries = 0
                },
            };
        }
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
