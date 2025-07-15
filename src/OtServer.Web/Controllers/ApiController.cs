using Microsoft.AspNetCore.Mvc;
using OtServer.Web.Services;
using OtServer.Web.ViewComponents;
using OtServer.Domain.Repositories;

namespace OtServer.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServerController : ControllerBase
    {
        private readonly ServerStatusService _serverStatusService;
        private readonly IPlayerRepository _playerRepository;

        public ServerController(ServerStatusService serverStatusService, IPlayerRepository playerRepository)
        {
            _serverStatusService = serverStatusService;
            _playerRepository = playerRepository;
        }

        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            var status = new ServerStatusViewModel
            {
                IsOnline = _serverStatusService.IsServerOnline(),
                StatusText = _serverStatusService.GetServerStatusText(),
                StatusClass = _serverStatusService.GetServerStatusClass()
            };

            return Ok(status);
        }

        [HttpGet("online-count")]
        public IActionResult GetOnlineCount()
        {
            var onlineCount = _playerRepository.GetOnlineList().Count;
            return Ok(new { count = onlineCount });
        }
    }
} 