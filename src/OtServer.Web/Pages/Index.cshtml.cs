using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OtServer.Domain.Enums;
using OtServer.Domain.Extensions;
using OtServer.Domain.Repositories;

namespace OtServer.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPlayerRepository _playerRepository;
        public List<PlayerHighscore> Players { get; set; } = new();
        public int OnlinePlayers { get; set; } 

        public IndexModel(ILogger<IndexModel> logger, IPlayerRepository playerRepository)
        {
            _logger = logger;
            _playerRepository = playerRepository;
        }

        public void OnGet()
        {
            Players = _playerRepository.GetPlayerRankLevel().Take(5).Select((x, idx) => new PlayerHighscore
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

            OnlinePlayers = _playerRepository.GetOnlineList().Count;
        }
    }
}
