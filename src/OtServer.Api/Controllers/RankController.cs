using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OtServer.Api.Utils;
using OtServer.Api.ViewModels;
using OtServer.Domain.Enums;
using OtServer.Domain.Repositories;

namespace OtServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public RankController(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }
        [HttpGet("Level")]
        public IActionResult GetAllOrderByLevel([FromQuery] int page = 1 )
        {
            int pageSize = 20;

            var players = _playerRepository.GetPlayerRankLevel();

            var pagedPlayers = players.Paginate(page, pageSize);

            return Ok(_mapper.Map<List<PlayerHighscore>>(pagedPlayers));
        }
        [HttpGet("Magic")]
        public IActionResult GetAllOrderByMagicLevel([FromQuery] int page = 1)
        {
            int pageSize = 20;

            var players = _playerRepository.GetPlayerRankMagicLevel();

            var pagedPlayers = players.Paginate(page, pageSize);

            return Ok(_mapper.Map<List<PlayerHighscore>>(pagedPlayers));
        }
        [HttpGet("Skill/{skillType}")]
        public IActionResult GetAllOrderByMagicLevel([FromRoute]SkillEnum skillType, [FromQuery] int page = 1)
        {
            int pageSize = 20;

            var players = _playerRepository.GetPlayerRankSkill(skillType);

            var pagedPlayers = players.Paginate(page, pageSize);

            return Ok(_mapper.Map<List<PlayerHighscore>>(pagedPlayers));
        }
    }
}
