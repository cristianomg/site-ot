using OtServer.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OtServer.Api.ViewModels
{
    public class CreatePlayerViewModel
    {
        [Required]
        [RegularExpression("^[A-Za-z]{6,19}$", ErrorMessage = "O nome deve conter apenas letras e ter entre 6 e 19 caracteres.")]
        public string Name { get; set; }
        [Range(0, 1)]
        public SexEnum Sex { get; set; }
        [Range(1, 4)]
        public VocationEnum Vocation { get; set; }
    }


    public enum CreatePlayerVocationEnum
    {
        Sorcerer = 1,
        Druid = 2,
        Archer = 3,
        Knight = 4,
    }

}
