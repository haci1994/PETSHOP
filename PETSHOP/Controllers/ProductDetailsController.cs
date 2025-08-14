using Microsoft.AspNetCore.Mvc;

namespace PETSHOP.Controllers
{
    public class ProductDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
