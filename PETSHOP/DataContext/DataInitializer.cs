using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PETSHOP.DataContext.Entities;
using System.Threading.Tasks;

namespace PETSHOP.DataContext
{
    public class DataInitializer
    {
        private readonly AppDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public DataInitializer(AppDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedData()
        {
            _dbContext.Database.Migrate();

            await CreateSuperAdmin();
        }

        public async Task CreateSuperAdmin()
        {
            List<string> roles = ["Admin", "Moderator", "User"];

            foreach(var role in roles)
            {
                var hasRole = await _roleManager.RoleExistsAsync(role);

                if (hasRole) continue;

                await _roleManager.CreateAsync(new IdentityRole { Name = role });
            }

            var existUser = await _userManager.FindByNameAsync("superadmin");

            if (existUser != null) return;

            var superAdmin = new AppUser
            {
                UserName = "superadmin",
                Email = "super@email"
            };

            var result = await _userManager.CreateAsync(superAdmin, "1234");

            if (!result.Succeeded) return;

            await _userManager.AddToRoleAsync(superAdmin, "Admin");
        }
    }
}
