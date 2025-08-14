using PETSHOP.DataContext.Entities;

namespace PETSHOP.Models
{
    public class LayoutViewModel
    {
        public WebsiteInfo SiteInfo { get; set; } = null!;
        public List<Social> Socials { get; set; } = null!;
    }
}
