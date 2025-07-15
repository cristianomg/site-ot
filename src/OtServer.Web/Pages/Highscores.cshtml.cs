using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OtServer.Domain.Entities;
using OtServer.Domain.Enums;
using OtServer.Domain.Extensions;
using OtServer.Domain.Repositories;

namespace OtServer.Web.Pages
{
    public enum RankingType
    {
        Level = 0,
        MagicLevel = 1,
        Fist = 2,
        Sword = 3,
        Distance = 4,
        Axe = 5,
        Club = 6
    }

    public class HighscoresModel : PageModel
    {

        private readonly IPlayerRepository _playerRepository;
        public HighscoresModel(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public List<PlayerHighscore> Players { get; set; } = new();
        public List<PlayerHighscore> AllPlayers { get; set; } = new();
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPlayers { get; set; }
        public RankingType CurrentRankingType { get; set; } = RankingType.Level;

        public void OnGet([FromQuery] int page = 1, [FromQuery] string type = "level")
        {

            List<OtServer.Domain.Entities.Player> query;
            List<OtServer.Domain.Entities.Skill> skillQuery = null;
            
            if (type.ToLower() == "magiclevel" || type.ToLower() == "magic")
            {
                query = _playerRepository.GetPlayerRankMagicLevel();
            }
            else if (type.ToLower() == "fist")
            {
                skillQuery = _playerRepository.GetPlayerRankSkill(SkillEnum.Fist);
                query = new List<Player>();
            }
            else if (type.ToLower() == "sword")
            {
                skillQuery = _playerRepository.GetPlayerRankSkill(SkillEnum.Sword);
                query = new List<Player>();
            }
            else if (type.ToLower() == "distance")
            {
                skillQuery = _playerRepository.GetPlayerRankSkill(SkillEnum.Distance);
                query = new List<Player>();
            }
            else if (type.ToLower() == "axe")
            {
                skillQuery = _playerRepository.GetPlayerRankSkill(SkillEnum.Axe);
                query = new List<Player>();
            }
            else if (type.ToLower() == "club")
            {
                skillQuery = _playerRepository.GetPlayerRankSkill(SkillEnum.Club);
                query = new List<Player>();
            }
            else
            {
                query = _playerRepository.GetPlayerRankLevel();
            }

            if (skillQuery != null)
            {
                AllPlayers = skillQuery.Select((x, idx) => new PlayerHighscore
                {
                    Position = idx + 1,
                    Name = x.Player.Name,
                    Vocation = ((VocationEnum)x.Player.Vocation).GetDescription(),
                    Resets = x.Player.Resets,
                    Level = x.Player.Level,
                    Experience = x.Player.Experience,
                    ManaSpent = x.Player.ManaSpent,
                    MagicLevel = x.Player.MagicLevel,
                    SkillLevel = x.SkillLevel
                }).ToList();
            }
            else
            {
                AllPlayers = query.Select((x, idx) => new PlayerHighscore
                {
                    Position = idx + 1,
                    Name = x.Name,
                    Vocation = ((VocationEnum)x.Vocation).GetDescription(),
                    Resets = x.Resets,
                    Level = x.Level,
                    Experience = x.Experience,
                    ManaSpent = x.ManaSpent,
                    MagicLevel = x.MagicLevel,
                }).ToList();
            }
            CurrentRankingType = type.ToLower() switch
            {
                "level" => RankingType.Level,
                "magiclevel" => RankingType.MagicLevel,
                "magic" => RankingType.MagicLevel,
                "fist" => RankingType.Fist,
                "sword" => RankingType.Sword,
                "distance" => RankingType.Distance,
                "axe" => RankingType.Axe,
                "club" => RankingType.Club,
                _ => RankingType.Level
            };


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
        public long ManaSpent { get; set; }
        public int MagicLevel { get; set; }
        public int SkillLevel { get; set; }
    }
} 