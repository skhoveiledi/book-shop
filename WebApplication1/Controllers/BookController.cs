using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebApplication1.Models.Domain.Entities;
using WebApplication1.Models.Services;

namespace WebApplication1.Controllers;

public class BookController : Controller
{
    private readonly BookService _bookService = new BookService();

    [HttpGet]
    public IActionResult Index()
    {
        var books = _bookService.GetAllBooks();
        ViewBag.Books = books;
        return View();
    }

    [HttpGet]
    public IActionResult Add()
    {
        var categories = _bookService.GetAllCategories();
        ViewBag.Categories = categories;
        return View();
    }

    [HttpGet]
    public IActionResult Categories()
    {
        var categories = _bookService.GetAllCategories();
        ViewBag.Categories = categories;
        return View();
    }

    [HttpGet]
    public IActionResult GetBooksInCategory(int id)
    {
        var cat = _bookService.GetBooksInCategory(id);
        return View("cat",cat);
    }

    [HttpPost]
    public IActionResult Add(Book book, IFormFile imageFile)
    {
        if (imageFile != null && imageFile.Length > 0)
        {
            var fileName = Path.GetFileName(imageFile.FileName);
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/books");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            book.ImagePath = "/images/books/" + fileName;
        }

        book.CreatedAt = DateTime.Now;
        _bookService.AddBook(book);
        

        return RedirectToAction("Index", "Home");
    }
}