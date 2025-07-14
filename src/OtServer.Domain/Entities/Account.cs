namespace OtServer.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RealName { get; set; }
        public string Location { get; set; }
        public bool Hide { get; set; }
        public bool HideEmail { get; set; }

        public List<Player> Players { get; set; }
    }
}
