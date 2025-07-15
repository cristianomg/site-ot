using Microsoft.AspNetCore.Mvc;
using OtServer.Web.Services;

namespace OtServer.Web.ViewComponents
{
    public class ServerStatusViewComponent : ViewComponent
    {
        private readonly ServerStatusService _serverStatusService;

        public ServerStatusViewComponent(ServerStatusService serverStatusService)
        {
            _serverStatusService = serverStatusService;
        }

        public IViewComponentResult Invoke()
        {
            var model = new ServerStatusViewModel
            {
                IsOnline = _serverStatusService.IsServerOnline(),
                StatusText = _serverStatusService.GetServerStatusText(),
                StatusClass = _serverStatusService.GetServerStatusClass()
            };

            return View(model);
        }
    }

    public class ServerStatusViewModel
    {
        public bool IsOnline { get; set; }
        public string StatusText { get; set; } = string.Empty;
        public string StatusClass { get; set; } = string.Empty;
    }
} 