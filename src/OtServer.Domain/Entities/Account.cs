namespace OtServer.Domain.Entities
{
    public class Account
    {

        public Account(int accountNumber, string password, string email, string realName, string location)
        {
            AccountNumber = accountNumber;
            Password = password;
            Email = email;
            RealName = realName;
            Location = location;
        }
        public int Id { get; set; }
        public int AccountNumber { get; set; }
        public int Type { get; set; }
        public int PremDays { get; set; }
        public int PremEnd { get; set; }
        public int Blocked { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RealName { get; set; }
        public string Location { get; set; }
        public bool Hide { get; set; }
        public bool HideEmail { get; set; }

        public List<Player> Players { get; set; }
    }
}
