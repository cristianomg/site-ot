using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace OtServer.Web.Services
{
    public class ServerStatusService
    {
        private readonly string _serverIp;
        private readonly int _serverPort;

        public ServerStatusService(IConfiguration configuration)
        {
            _serverIp = configuration["ServerSettings:Ip"] ?? "127.0.0.1";
            _serverPort = int.Parse(configuration["ServerSettings:Port"] ?? "7171");
        }

        public bool IsServerOnline()
        {
            // Método 1: Tentativa de conexão socket
            if (TrySocketConnection())
                return true;

            // Método 2: Ping
            if (TryPing())
                return true;

            return false;
        }

        private bool TrySocketConnection()
        {
            try
            {
                using (var client = new TcpClient())
                {
                    var result = client.BeginConnect(_serverIp, _serverPort, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2));
                    
                    if (success)
                    {
                        client.EndConnect(result);
                        return true;
                    }
                }
            }
            catch
            {
                // Ignora erros de conexão
            }
            return false;
        }

        private bool TryPing()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = ping.Send(_serverIp, 2000);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                // Ignora erros de ping
            }
            return false;
        }

        public string GetServerStatusText()
        {
            return IsServerOnline() ? "🟢 Online" : "🔴 Offline";
        }

        public string GetServerStatusClass()
        {
            return IsServerOnline() ? "text-success" : "text-danger";
        }
    }
} 