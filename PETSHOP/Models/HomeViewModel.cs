using PETSHOP.DataContext.Entities;

namespace PETSHOP.Models
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; } = [];
        public List<Product> Products { get; set; } = [];
    }
}
