using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OtServer.Web.Pages
{
    public enum RankingType
    {
        Level = 0,
        MagicLevel = 1,
        First = 2,
        Sword = 3,
        Distance = 4,
        Axe = 5,
        Club = 6
    }

    public class HighscoresModel : PageModel
    {
        public List<PlayerHighscore> Players { get; set; } = new();
        public List<PlayerHighscore> AllPlayers { get; set; } = new();
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPlayers { get; set; }
        public RankingType CurrentRankingType { get; set; } = RankingType.Level;

        public void OnGet([FromQuery] int page = 1, [FromQuery] string type = "level")
        {
            // Configuração de parâmetros
            
            // Determinar tipo de ranking
            CurrentRankingType = type.ToLower() switch
            {
                "level" => RankingType.Level,
                "magiclevel" => RankingType.MagicLevel,
                "magic" => RankingType.MagicLevel,
                "first" => RankingType.First,
                "sword" => RankingType.Sword,
                "distance" => RankingType.Distance,
                "axe" => RankingType.Axe,
                "club" => RankingType.Club,
                _ => RankingType.Level
            };
            
            // Dados mock de players para demonstração
            AllPlayers = new List<PlayerHighscore>
            {
                new PlayerHighscore { Position = 1, Name = "Soul Reaper", Vocation = "Elder Druid", Resets = 15, Level = 8, Experience = 4200, MagicLevel = 120, FirstSkill = 110, SwordSkill = 95, DistanceSkill = 105, AxeSkill = 88, ClubSkill = 92 },
                new PlayerHighscore { Position = 2, Name = "Dark Necromancer", Vocation = "Master Sorcerer", Resets = 14, Level = 89, Experience = 5445692, MagicLevel = 135, FirstSkill = 125, SwordSkill = 87, DistanceSkill = 92, AxeSkill = 85, ClubSkill = 89 },
                new PlayerHighscore { Position = 3, Name = "Shadow Walker", Vocation = "Elite Knight", Resets = 14, Level = 76, Experience = 4892347, MagicLevel = 45, FirstSkill = 118, SwordSkill = 130, DistanceSkill = 85, AxeSkill = 125, ClubSkill = 128 },
                new PlayerHighscore { Position = 4, Name = "Void Hunter", Vocation = "Royal Paladin", Resets = 13, Level = 91, Experience = 6234156, MagicLevel = 75, FirstSkill = 115, SwordSkill = 110, DistanceSkill = 140, AxeSkill = 108, ClubSkill = 112 },
                new PlayerHighscore { Position = 5, Name = "Darkness Lord", Vocation = "Elder Druid", Resets = 13, Level = 84, Experience = 5123789, MagicLevel = 128, FirstSkill = 122, SwordSkill = 93, DistanceSkill = 98, AxeSkill = 91, ClubSkill = 95 },
                new PlayerHighscore { Position = 6, Name = "Death Bringer", Vocation = "Master Sorcerer", Resets = 12, Level = 95, Experience = 7891234, MagicLevel = 142, FirstSkill = 132, SwordSkill = 89, DistanceSkill = 94, AxeSkill = 87, ClubSkill = 91 },
                new PlayerHighscore { Position = 7, Name = "Blood Thirsty", Vocation = "Elite Knight", Resets = 12, Level = 87, Experience = 5567890, MagicLevel = 48, FirstSkill = 120, SwordSkill = 138, DistanceSkill = 88, AxeSkill = 135, ClubSkill = 133 },
                new PlayerHighscore { Position = 8, Name = "Corrupted Soul", Vocation = "Royal Paladin", Resets = 11, Level = 93, Experience = 6789123, MagicLevel = 78, FirstSkill = 118, SwordSkill = 115, DistanceSkill = 145, AxeSkill = 112, ClubSkill = 117 },
                new PlayerHighscore { Position = 9, Name = "Fallen Angel", Vocation = "Elder Druid", Resets = 11, Level = 79, Experience = 4567123, MagicLevel = 125, FirstSkill = 119, SwordSkill = 91, DistanceSkill = 96, AxeSkill = 89, ClubSkill = 93 },
                new PlayerHighscore { Position = 10, Name = "Nightmare King", Vocation = "Master Sorcerer", Resets = 10, Level = 98, Experience = 8234567, MagicLevel = 148, FirstSkill = 138, SwordSkill = 92, DistanceSkill = 97, AxeSkill = 90, ClubSkill = 94 },
                new PlayerHighscore { Position = 11, Name = "Abyss Walker", Vocation = "Elite Knight", Resets = 10, Level = 85, Experience = 5234567, MagicLevel = 42, FirstSkill = 116, SwordSkill = 132, DistanceSkill = 83, AxeSkill = 129, ClubSkill = 127 },
                new PlayerHighscore { Position = 12, Name = "Demon Slayer", Vocation = "Royal Paladin", Resets = 9, Level = 92, Experience = 6345678, MagicLevel = 76, FirstSkill = 114, SwordSkill = 108, DistanceSkill = 138, AxeSkill = 105, ClubSkill = 110 },
                new PlayerHighscore { Position = 13, Name = "Lost Wanderer", Vocation = "Elder Druid", Resets = 9, Level = 73, Experience = 3987654, MagicLevel = 118, FirstSkill = 112, SwordSkill = 86, DistanceSkill = 91, AxeSkill = 84, ClubSkill = 88 },
                new PlayerHighscore { Position = 14, Name = "Cursed Warrior", Vocation = "Elite Knight", Resets = 8, Level = 94, Experience = 7123456, MagicLevel = 46, FirstSkill = 121, SwordSkill = 136, DistanceSkill = 86, AxeSkill = 133, ClubSkill = 131 },
                new PlayerHighscore { Position = 15, Name = "Phantom Archer", Vocation = "Royal Paladin", Resets = 8, Level = 81, Experience = 4789123, MagicLevel = 69, FirstSkill = 109, SwordSkill = 102, DistanceSkill = 132, AxeSkill = 99, ClubSkill = 104 },
                new PlayerHighscore { Position = 16, Name = "Venom Master", Vocation = "Master Sorcerer", Resets = 7, Level = 96, Experience = 7567890, MagicLevel = 145, FirstSkill = 135, SwordSkill = 90, DistanceSkill = 95, AxeSkill = 88, ClubSkill = 92 },
                new PlayerHighscore { Position = 17, Name = "Steel Guardian", Vocation = "Elite Knight", Resets = 7, Level = 78, Experience = 4234567, MagicLevel = 39, FirstSkill = 108, SwordSkill = 124, DistanceSkill = 79, AxeSkill = 121, ClubSkill = 119 },
                new PlayerHighscore { Position = 18, Name = "Spirit Caller", Vocation = "Elder Druid", Resets = 6, Level = 88, Experience = 5678901, MagicLevel = 122, FirstSkill = 116, SwordSkill = 88, DistanceSkill = 93, AxeSkill = 86, ClubSkill = 90 },
                new PlayerHighscore { Position = 19, Name = "Frost Blade", Vocation = "Royal Paladin", Resets = 6, Level = 75, Experience = 3876543, MagicLevel = 65, FirstSkill = 105, SwordSkill = 98, DistanceSkill = 128, AxeSkill = 95, ClubSkill = 100 },
                new PlayerHighscore { Position = 20, Name = "Void Assassin", Vocation = "Master Sorcerer", Resets = 6, Level = 82, Experience = 4156789, MagicLevel = 138, FirstSkill = 128, SwordSkill = 85, DistanceSkill = 90, AxeSkill = 83, ClubSkill = 87 },
                new PlayerHighscore { Position = 21, Name = "Bone Crusher", Vocation = "Elite Knight", Resets = 5, Level = 77, Experience = 3789234, MagicLevel = 38, FirstSkill = 107, SwordSkill = 122, DistanceSkill = 78, AxeSkill = 119, ClubSkill = 117 },
                new PlayerHighscore { Position = 22, Name = "Arrow Storm", Vocation = "Royal Paladin", Resets = 5, Level = 74, Experience = 3654321, MagicLevel = 62, FirstSkill = 103, SwordSkill = 96, DistanceSkill = 125, AxeSkill = 93, ClubSkill = 98 },
                new PlayerHighscore { Position = 23, Name = "Mystic Shaman", Vocation = "Elder Druid", Resets = 5, Level = 80, Experience = 4023456, MagicLevel = 115, FirstSkill = 109, SwordSkill = 82, DistanceSkill = 87, AxeSkill = 80, ClubSkill = 84 },
                new PlayerHighscore { Position = 24, Name = "Fire Lord", Vocation = "Master Sorcerer", Resets = 4, Level = 72, Experience = 3234567, MagicLevel = 132, FirstSkill = 122, SwordSkill = 78, DistanceSkill = 83, AxeSkill = 76, ClubSkill = 80 },
                new PlayerHighscore { Position = 25, Name = "Iron Fist", Vocation = "Elite Knight", Resets = 4, Level = 70, Experience = 3123456, MagicLevel = 35, FirstSkill = 101, SwordSkill = 116, DistanceSkill = 72, AxeSkill = 113, ClubSkill = 120 },
                new PlayerHighscore { Position = 26, Name = "Swift Arrow", Vocation = "Royal Paladin", Resets = 4, Level = 68, Experience = 2987654, MagicLevel = 58, FirstSkill = 97, SwordSkill = 90, DistanceSkill = 118, AxeSkill = 87, ClubSkill = 92 },
                new PlayerHighscore { Position = 27, Name = "Earth Walker", Vocation = "Elder Druid", Resets = 3, Level = 65, Experience = 2789123, MagicLevel = 108, FirstSkill = 102, SwordSkill = 75, DistanceSkill = 80, AxeSkill = 73, ClubSkill = 77 },
                new PlayerHighscore { Position = 28, Name = "Ice Mage", Vocation = "Master Sorcerer", Resets = 3, Level = 63, Experience = 2654789, MagicLevel = 125, FirstSkill = 115, SwordSkill = 71, DistanceSkill = 76, AxeSkill = 69, ClubSkill = 73 },
                new PlayerHighscore { Position = 29, Name = "Battle Axe", Vocation = "Elite Knight", Resets = 3, Level = 61, Experience = 2456123, MagicLevel = 31, FirstSkill = 95, SwordSkill = 110, DistanceSkill = 68, AxeSkill = 125, ClubSkill = 107 }
            };

            // Ordenar baseado no tipo de ranking selecionado
            AllPlayers = CurrentRankingType switch
            {
                RankingType.Level => AllPlayers.OrderByDescending(p => p.Resets).ThenByDescending(p => p.Level).ToList(),
                RankingType.MagicLevel => AllPlayers.OrderByDescending(p => p.MagicLevel).ThenByDescending(p => p.Level).ToList(),
                RankingType.First => AllPlayers.OrderByDescending(p => p.FirstSkill).ThenByDescending(p => p.Level).ToList(),
                RankingType.Sword => AllPlayers.OrderByDescending(p => p.SwordSkill).ThenByDescending(p => p.Level).ToList(),
                RankingType.Distance => AllPlayers.OrderByDescending(p => p.DistanceSkill).ThenByDescending(p => p.Level).ToList(),
                RankingType.Axe => AllPlayers.OrderByDescending(p => p.AxeSkill).ThenByDescending(p => p.Level).ToList(),
                RankingType.Club => AllPlayers.OrderByDescending(p => p.ClubSkill).ThenByDescending(p => p.Level).ToList(),
                _ => AllPlayers.OrderByDescending(p => p.Resets).ThenByDescending(p => p.Level).ToList()
            };

            // Reordenar as posições após a ordenação
            for (int i = 0; i < AllPlayers.Count; i++)
            {
                AllPlayers[i].Position = i + 1;
            }

            Console.WriteLine(page);

            // Configurar paginação
            CurrentPage = Math.Max(1, page);
            TotalPlayers = AllPlayers.Count;
            TotalPages = (int)Math.Ceiling((double)TotalPlayers / PageSize);
            CurrentPage = Math.Min(CurrentPage, TotalPages);
            
            // Obter players da página atual
            Players = AllPlayers
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }
    }

    public class PlayerHighscore
    {
        public int Position { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Vocation { get; set; } = string.Empty;
        public int Resets { get; set; }
        public int Level { get; set; }
        public long Experience { get; set; }
        public int MagicLevel { get; set; }
        public int FirstSkill { get; set; }
        public int SwordSkill { get; set; }
        public int DistanceSkill { get; set; }
        public int AxeSkill { get; set; }
        public int ClubSkill { get; set; }
    }
} 