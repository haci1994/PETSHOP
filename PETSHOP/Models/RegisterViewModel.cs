using System.ComponentModel.DataAnnotations;

namespace PETSHOP.Models
{
    public class RegisterViewModel
    {
        public required string UserName {get; set;}

        public string? FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [DataType(DataType.Password)]
        
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Kodlar üst-üstə düşmür!")]
        public required string ConfirmPassword { get; set; }
    }
}
