using System.Buffers;

namespace OtServer.Domain.Entities
{
    public class Guild
    {
        public int GuildId { get; set; }
        public string GuildName { get; set; }
        public int OwnerId { get; set; }
        public string GuildStory { get; set; }
        public virtual Player Owner { get; set; }
        public virtual List<GuildInvited> Members { get; set; }
    }
}
