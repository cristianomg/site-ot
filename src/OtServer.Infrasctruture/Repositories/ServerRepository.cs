using Microsoft.Extensions.Configuration;
using OtServer.Domain.Entities;
using OtServer.Domain.Repositories;
using System.Net.Sockets;

namespace OtServer.Infrasctruture.Repositories
{
    public class ServerRepository : IServerRepository
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly string _serverIp;
        private readonly int _serverPort;
        private readonly string _onlineListPath;

        public ServerRepository(IPlayerRepository playerRepository, IConfiguration configuration)
        {
            _playerRepository = playerRepository;
            _serverIp = configuration["ServerSettings:Ip"] ?? "127.0.0.1";
            _serverPort = int.Parse(configuration["ServerSettings:Port"] ?? "7171");
            _onlineListPath = configuration["ServerSettings:OnlineListPath"] ?? throw new ArgumentNullException("O caminho para o arquivo online.php não foi configurado.");
        }

        public IEnumerable<Player?> GetPlayersOnline()
        {
            foreach (var p in GetOnlineList())
            {
                yield return _playerRepository.GetByName(p);
            }
        }

        public bool GetServerStatus()
        {
            return TrySocketConnection();
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

        private List<string> GetOnlineList()
        {
            var onlinePlayers = new List<string>();
            var filePath = _onlineListPath;

            try
            {
                if (File.Exists(filePath))
                {
                    var content = File.ReadAllText(filePath);

                    // Procura pelo padrão "Players online: " seguido dos nomes
                    if (content.Contains("Players online:"))
                    {
                        var startIndex = content.IndexOf("Players online:") + "Players online:".Length;
                        var endIndex = content.IndexOf(". Total:");

                        if (endIndex > startIndex)
                        {
                            var playersString = content.Substring(startIndex, endIndex - startIndex).Trim();

                            // Divide a string pelos nomes separados por vírgula
                            var players = playersString.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                                     .Select(p => p.Trim())
                                                     .Where(p => !string.IsNullOrEmpty(p))
                                                     .ToList();

                            onlinePlayers.AddRange(players);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler arquivo online.php: {ex.Message}");
            }

            return onlinePlayers;
        }

    }
}
