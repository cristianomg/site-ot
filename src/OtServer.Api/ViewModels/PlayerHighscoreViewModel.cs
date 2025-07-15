namespace OtServer.Api.ViewModels
{
    public class PlayerHighscore
    {
        public string Name { get; set; } = string.Empty;
        public string Vocation { get; set; } = string.Empty;
        public int Resets { get; set; }
        public int Level { get; set; }
        public long Experience { get; set; }
        public int MagicLevel { get; set; }
        public int SkillLevel { get; set; }
    }
}
