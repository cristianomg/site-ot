using System.ComponentModel.DataAnnotations;

namespace OtServer.Api.ViewModels
{
    public class CreateAccountViewModel
    {
        [Required]
        public int Account { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required] 
        public string RealName { get; set; }
        [Required]
        [EmailAddress()]
        public string Email { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
