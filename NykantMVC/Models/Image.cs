namespace NykantMVC.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
