using Microsoft.AspNetCore.Mvc;
using OtServer.Domain.Repositories;

namespace OtServer.Web.ViewComponents
{
    public class OnlinePlayersViewComponent : ViewComponent
    {
        private readonly IPlayerRepository _playerRepository;

        public OnlinePlayersViewComponent(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public IViewComponentResult Invoke()
        {
            var onlineCount = _playerRepository.GetOnlineList().Count;
            return View(onlineCount);
        }
    }
} 