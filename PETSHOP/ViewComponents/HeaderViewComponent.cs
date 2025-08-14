using Microsoft.AspNetCore.Mvc;
using PETSHOP.DataContext;
using PETSHOP.Models;

namespace PETSHOP.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public HeaderViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var info = _dbContext.WebsiteInfos.ToList().FirstOrDefault();

            var socials = _dbContext.Socials.ToList();

            var model = new LayoutViewModel
            {
                Socials = socials,
                SiteInfo = info
            };

            return View(model);
        }
    }
}
