using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OtServer.Api.ViewModels;
using OtServer.Domain.Repositories;

namespace OtServer.Api.Controllers
{
    [Route("api/[controller]")]
    public class ServerController : ControllerBase
    {
        private readonly IServerRepository _serverRepository;
        private readonly IMapper _mapper;

        public ServerController(IServerRepository serverRepository, IMapper mapper)
        {
            _serverRepository = serverRepository;
            _mapper = mapper;
        }

        [HttpGet("Status")]
        public IActionResult GetServerIsOnline()
        {
            return Ok(_serverRepository.GetServerStatus());
        }

        [HttpGet("Online-List")]
        public IActionResult GetOnlineList()
        {
            var playersOnline = _serverRepository.GetPlayersOnline();

            return Ok(_mapper.Map<List<PlayerInfoViewModel>>(playersOnline));
        }
    }
}
