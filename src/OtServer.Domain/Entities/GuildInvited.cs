namespace OtServer.Domain.Entities
{
    public class GuildInvited
    {
        public int GuildId { get; set; }
        public int PlayerId { get; set; }
        public string GuildRank { get; set; }
        public virtual Player Player { get; set; }
        public virtual Guild Guild { get; set; }
    }
}
