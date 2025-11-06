using WebApplication1.Models.Domain.Entities;

namespace WebApplication1.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Book> LatestBooks { get; set; } = new List<Book>();
    }
}
