using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PETSHOP.DataContext;
using PETSHOP.Models;

namespace PETSHOP.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var slider = _dbContext.Sliders.ToList();
            var products = _dbContext.Products.Take(3).ToList();

            var model = new HomeViewModel
            {
                Sliders = slider,
                Products = products
            };

            return View(model);
        }

    }
}
