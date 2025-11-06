using WebApplication1.Models.Domain.Entities;

namespace WebApplication1.Models.Application.InfraStructor.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetLatestBooks(int take);
        List<Category>? GetAllCategories();
        void AddBook(Book book);
        Book? GetById(int bookId);
        List<Book> GetAllBooks();
    }
}
