using PETSHOP.DataContext.Entities;

namespace PETSHOP.Models
{
    public class ShopViewModel
    {
        public List<Product> Products { get; set; } = [];
        public int ProductCount { get; set; }
    }
}
