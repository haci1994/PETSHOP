using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PETSHOP.DataContext.Entities;
using PETSHOP.Models;

namespace PETSHOP.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var myuser = new AppUser
            {
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName,
            };

            var result = await _userManager.CreateAsync(myuser, user.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

               return View(user);
            }

            var adminRoleResult = await _roleManager.CreateAsync(new IdentityRole
            { 
                Name = "Admin"
            });

            if(adminRoleResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(myuser, "Admin");
            }    

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }

           
            var loggedUser = await _userManager.FindByNameAsync(user.Username);

            if (loggedUser == null)
            {
                ModelState.AddModelError("", "Username or Password is not correct!");

                return View(user);
            }

            var result = await _signInManager.PasswordSignInAsync(loggedUser, user.Password, user.RememberMe,false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password is not correct!");

                return View(user);
            }

            if (!string.IsNullOrEmpty(user.ReturnUrl))
            {
                return Redirect(user.ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
