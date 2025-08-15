using PETSHOP.DataContext.Entities;

namespace PETSHOP.Models
{
    public class SingleProductModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string CoverImageUrl { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public List<ProductImage> Images { get; set; } = [];
        public List<ProductTag> Tags { get; set; } = [];
    }
}
