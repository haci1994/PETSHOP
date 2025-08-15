using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PETSHOP.DataContext;
using PETSHOP.DataContext.Entities;
using PETSHOP.Models;

namespace PETSHOP.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private const string BASKET_KEY = "petshop-basket";

        private readonly AppDbContext _dbContext;

        public HeaderViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var info = _dbContext.WebsiteInfos.ToList().FirstOrDefault();

            var socials = _dbContext.Socials.ToList();

            var products = new List<Product>();

            var productsCookie = GetBasket();

            foreach(var item in productsCookie)
            {
                var exist = _dbContext.Products.FirstOrDefault(x => x.Id == item.ProductId);

                if (exist == null) continue;

                products.Add(exist);
            }

            var model = new LayoutViewModel
            {
                Socials = socials,
                SiteInfo = info,
                BasketItems = products
            };

            return View(model);
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
