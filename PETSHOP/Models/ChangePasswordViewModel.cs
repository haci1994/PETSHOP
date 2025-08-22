using System.ComponentModel.DataAnnotations;

namespace PETSHOP.Models
{
    public class ChangePasswordViewModel
    {
        public required string CurrentPassword { get; set; }

        [DataType(DataType.Password)]

        public required string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage ="Kodlar ust-uste dusmur!")]
        public required string ConfirmPassword { get; set; }
    }
}
