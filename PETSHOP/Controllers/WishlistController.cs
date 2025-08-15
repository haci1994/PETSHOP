using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PETSHOP.DataContext;
using PETSHOP.Models;

namespace PETSHOP.Controllers
{
    public class WishlistController : Controller
    {
        private const string WISHLIST_KEY = "petshopWishlist";

        private readonly AppDbContext _dbContext;

        public WishlistController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var productsCookie = GetWishlist();

            var products = new List<WishlistModel>();

            foreach(var item in productsCookie)
            {
                var pr = _dbContext.Products.FirstOrDefault(x => x.Id == item);

                if (pr == null) continue;

                products.Add(new WishlistModel
                {
                    ImageUrl = pr.CoverImageUrl,
                    Name = pr.Name,
                    Price = pr.Price,
                    ProductId = pr.Id
                });
            }

            return View(products);
        }

        public IActionResult AddToWishlist(int id)
        {
            if (_dbContext.Products.Find(id) == null) return BadRequest();

            var products = GetWishlist();

            int exist = products.FirstOrDefault(x => x == id);

            if (exist < 1)
            {
                products.Add(id);
            } else
            {
                products.Remove(id);
            }

                var productJson = JsonConvert.SerializeObject(products);

            Response.Cookies.Append(WISHLIST_KEY, productJson);

            return RedirectToAction("Index", "Shop");
        }

        public List<int> GetWishlist()
        {
            var productsJson = Request.Cookies[WISHLIST_KEY];

            var products = new List<int>();

            if (!string.IsNullOrEmpty(productsJson))
            {
                products = JsonConvert.DeserializeObject<List<int>>(productsJson);
            }

            return products;
        }
    }
}
