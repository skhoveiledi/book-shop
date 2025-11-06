using System.Security.Cryptography.X509Certificates;

namespace WebApplication1.Models.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; } = "";
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
