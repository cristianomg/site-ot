using Microsoft.AspNetCore.Mvc.RazorPages;
using OtServer.Domain.Entities;
using OtServer.Domain.Repositories;

namespace OtServer.Web.Pages
{
    public class PlayersOnlineModel : PageModel
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayersOnlineModel(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public List<Player?> PlayersOnline { get; set; } = new List<Player?>();
        public List<string> OnlinePlayerNames { get; set; } = new List<string>();

        public void OnGet()
        {
            PlayersOnline = _playerRepository.GetPlayersOnline().ToList();
        }
    }
} 