namespace PETSHOP.DataContext.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<ProductTag> ProductTags { get; set; } = [];
    }
}
