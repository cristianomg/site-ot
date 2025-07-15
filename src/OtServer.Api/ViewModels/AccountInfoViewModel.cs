namespace OtServer.Api.ViewModels
{
    public class AccountInfoViewModel
    {
        public int AccountNumber { get; set; }
        public string Email { get; set; }
        public string RealName { get; set; }
        public string Location { get; set; }
        public List<PlayerInfoViewModel> Players { get; set; }

    }
}
