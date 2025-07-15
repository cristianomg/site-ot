using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OtServer.Domain.Entities;
using OtServer.Domain.Enums;
using OtServer.Domain.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace OtServer.Web.Pages
{
    public class CharacterModel : PageModel
    {
        private readonly IPlayerRepository _playerRepository;
        public CharacterModel(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public Player? Player { get; set; }
        public List<Player> OtherCharacters { get; set; } = new();
        public List<PlayerDeath> Deaths { get; set; } = new();

        public void OnGet(string name)
        {
            Name = name;
            Player = _playerRepository.GetByName(name);
               

            if (Player != null)
            {
                if (Player.Account != null && Player.Account.Players != null)
                {
                    OtherCharacters = Player.Account.Players
                        .Where(p => p.Name.ToLower() != name.ToLower())
                        .ToList();
                }
                Deaths = _playerRepository.GetDeathByName(name).Select(x => new PlayerDeath
                {
                    Date = DateTimeOffset.FromUnixTimeSeconds(x.Date).DateTime.ToString(),
                    Description = $"Killed at level {x.Level} by {x.KillerName}"
                }).ToList();
            }
        }

        public class PlayerDeath
        {
            public string Date { get; set; }
            public string Description { get; set; }
        }
    }
} 