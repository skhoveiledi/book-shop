using WebApplication1.Models.Domain.Entities;

namespace WebApplication1.Models.Application.InfraStructor.Interfaces.Services
{
    public interface IBookService
    {
        List<Category>? GetAllCategories();
        List<Book>? GetLatestBooks();
        void AddBook(Book book);
        Book? GetById(int bookId);
        List<Book> GetAllBooks();
    }
}
