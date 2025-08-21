using Microsoft.AspNetCore.Identity;

namespace PETSHOP.DataContext.Entities
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
