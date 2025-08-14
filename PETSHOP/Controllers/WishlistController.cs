using Microsoft.AspNetCore.Mvc;

namespace PETSHOP.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
