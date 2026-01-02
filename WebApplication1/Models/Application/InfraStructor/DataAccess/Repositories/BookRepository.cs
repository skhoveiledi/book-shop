using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Application.InfraStructor.Interfaces;
using WebApplication1.Models.Config;
using WebApplication1.Models.Domain.Entities;

namespace WebApplication1.Models.Application.InfraStructor.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository()
        {
            _context = new AppDbContext();
        }
        public List<Book> GetLatestBooks(int take)
        {
            return _context.Books.OrderByDescending(b => b.CreatedAt)
                .Take(take)
                .ToList();
        }

        public List<Category>? GetAllCategories()
        {
            return _context.Categories
                .OrderByDescending(c => c.Name)
                .ToList();
        }

        public void AddBook(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }

        public Book? GetById(int bookId)
        {
            return _context.Books.Find(bookId);
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books
                .Include(b => b.Category)
                .OrderByDescending(b => b.CreatedAt)
                .ToList();
        }

        public List<Book> GetBooksInCategory(int categoryId)
        {
            return _context.Books.Include(b=>b.Category)
                .Where(b=>b.CategoryId==categoryId)
                .ToList();
        }
    }
}
