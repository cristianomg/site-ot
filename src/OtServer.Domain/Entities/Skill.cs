namespace OtServer.Domain.Entities
{
    public class Skill
    {
        public int PlayerId { get; set; }
        public int Id { get; set; }
        public int SkillLevel { get; set; }
        public int Tries { get; set; }
        public virtual Player Player { get; set; }
    }
}
