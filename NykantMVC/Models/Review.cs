using System.ComponentModel.DataAnnotations;

namespace NykantMVC.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public int Stars { get; set; }
    }
}
