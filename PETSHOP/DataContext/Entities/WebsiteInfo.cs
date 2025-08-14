namespace PETSHOP.DataContext.Entities
{
    public class WebsiteInfo
    {
        public int Id { get; set; }
        public string LogoUrl { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Mail {get; set;} = null!;
        public string Copyright { get; set; } = null!; 

    }
}
