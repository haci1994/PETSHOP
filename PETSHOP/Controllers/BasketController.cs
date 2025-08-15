using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PETSHOP.DataContext;
using PETSHOP.Models;
using System.Text.Json.Serialization;

namespace PETSHOP.Controllers
{
    public class BasketController : Controller
    {
        private const string BASKET_KEY = "petshop-basket";

        private readonly AppDbContext _dbContext;

        public BasketController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToBasket(int id)
        {
            if (id == null || id < 1) return BadRequest();

            if (_dbContext.Products.Where(x => x.Id == id) == null) return NotFound();

            var basket = GetBasket();

            var product = basket.Find(x => x.ProductId == id);

            if (product != null)
            {
                product.Count++;
            }
            else
            {
                basket.Add(new BasketModel { Count = 1, ProductId = id });
            }

            var basketJson = JsonConvert.SerializeObject(basket);

            Response.Cookies.Append(BASKET_KEY, basketJson.ToString());

            return RedirectToAction("Index", "Shop");
        }

        public List<BasketModel> GetBasket()
        {
            var basketCookie = Request.Cookies[BASKET_KEY];
            var basket = new List<BasketModel>();

            if (!string.IsNullOrEmpty(basketCookie))
            {
                basket = JsonConvert.DeserializeObject<List<BasketModel>>(basketCookie);
            }

            return basket;
        }
    }
}
