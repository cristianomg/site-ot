using OtServer.Domain.Entities;

namespace OtServer.Api.ViewModels
{
    public class DeathListViewModel
    {
        public int Level { get; set; }
        public int  PlayerId { get; set; }
        public string PlayerName { get; set; }

        public DateTime Date { get; set; }
        public string KillerName { get; set; }
        public bool KillerIsPlayer { get; set; }


        public static DeathListViewModel FromDeathList(DeathList deathlist, bool killerIsPlayer)
        {
            return new DeathListViewModel
            {
                Date = DateTimeOffset.FromUnixTimeSeconds(deathlist.Date).DateTime,
                Level = deathlist.Level,
                KillerIsPlayer = killerIsPlayer,
                KillerName = deathlist.KillerName,
                PlayerId = deathlist.PlayerId,
                PlayerName = deathlist.Player.Name
            };
        }
    }
}
