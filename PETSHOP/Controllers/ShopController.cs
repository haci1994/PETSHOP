using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PETSHOP.DataContext;
using PETSHOP.Models;

namespace PETSHOP.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ShopController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var products = _dbContext.Products.Take(3).ToList();

            var model = new ShopViewModel
            {
                Products = products
            };

            return View(model);
        }

        public IActionResult LoadMore(int skip)
        {
            var productList = _dbContext.Products
                .Skip(skip)
                .Take(3)
                .ToList();

            return Json(productList);
        }
    }
}
