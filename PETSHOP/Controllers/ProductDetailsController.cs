using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PETSHOP.DataContext;
using PETSHOP.Models;

namespace PETSHOP.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProductDetailsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int id)
        {
            var product = _dbContext
                .Products
                .Include(z => z.Category)
                .Include(t=> t.Images)
                .Include(h => h.ProductTags)
                .ThenInclude(y => y.Tag)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            var model = new SingleProductModel
            {
                Category = product.Category.Name,
                CoverImageUrl = product.CoverImageUrl,
                Name = product.Name,
                Id = product.Id,
                Price = product.Price,
                Images = product.Images,
                Tags = product.ProductTags
            };


            return View(model);
        }
    }
}
