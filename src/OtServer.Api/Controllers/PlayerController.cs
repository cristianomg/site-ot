using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OtServer.Api.ViewModels;
using OtServer.Domain.Repositories;

namespace OtServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }
        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var player = _playerRepository.GetByName(name);

            return Ok(_mapper.Map<PlayerInfoViewModel>(player));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var player = _playerRepository.GetById(id);
            return Ok(_mapper.Map<PlayerInfoViewModel>(player));
        }
    }
}
