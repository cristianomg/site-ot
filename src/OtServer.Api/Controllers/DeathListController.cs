using Microsoft.AspNetCore.Mvc;
using OtServer.Api.ViewModels;
using OtServer.Domain.Entities;
using OtServer.Domain.Repositories;

namespace OtServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeathListController : ControllerBase
    {
        private readonly IDeathListRepository _deathListRepository;
        private readonly IPlayerRepository _playerRepository;

        public DeathListController(IDeathListRepository deathListRepository, IPlayerRepository playerRepository)
        {
            _deathListRepository = deathListRepository;
            _playerRepository = playerRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var deaths = _deathListRepository.GetLast20();

            return Ok(MapToViewModel(deaths));
        }

        [HttpGet("{playerName}")]
        public IActionResult Get(string playerName)
        {
            var deaths = _deathListRepository.GetByPlayerName(playerName);

            return Ok(MapToViewModel(deaths));
        }

        private IEnumerable<DeathListViewModel>MapToViewModel(List<DeathList> deaths)
        {

            foreach (var death in deaths)
            {
                var isKillerPlayer = _playerRepository.IsPlayer(death.KillerName);
                yield return DeathListViewModel.FromDeathList(death, isKillerPlayer);
            }
        }
    }
}
