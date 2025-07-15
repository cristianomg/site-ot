namespace OtServer.Domain.Entities
{
    public class DeathList
    {
        public int PlayerId { get; set; }
        public string KillerName { get; set; }
        public int Level { get; set; }
        public long Date { get; set; }
        public Player Player { get; set; }
    }
}
