using WebApplication1.Models.Application.InfraStructor.DataAccess.Repositories;
using WebApplication1.Models.Application.InfraStructor.Interfaces;
using WebApplication1.Models.Application.InfraStructor.Interfaces.Services;
using WebApplication1.Models.Domain.Entities;

namespace WebApplication1.Models.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }
        public List<Category>? GetAllCategories()
        {
            return _bookRepository.GetAllCategories();

        }

        public List<Book>? GetLatestBooks()
        {
            return _bookRepository.GetLatestBooks(5);
        }

        public void AddBook(Book book)
        {
            if (book.Price >= 0)
                _bookRepository.AddBook(book);
        }

        public Book? GetById(int bookId)
        {
            return _bookRepository.GetById(bookId);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public List<Book> GetBooksInCategory(int categoryId)
        {
            return _bookRepository.GetBooksInCategory(categoryId);
        }
    }
}
