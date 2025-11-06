using WebApplication1.Models.Application.InfraStructor.Interfaces;
using WebApplication1.Models.Config;
using WebApplication1.Models.Domain.Entities;

namespace WebApplication1.Models.Application.InfraStructor.DataAccess.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository()
    {
        _context = new AppDbContext();
    }
    public List<Category> getAllCategories()
    {
        return _context.Categories
            .OrderByDescending(c=>c.Name)
            .ToList();
    }

    public Category? GetCategoryById(int id)
    {
        return _context.Categories.FirstOrDefault(c => c.Id == id);
    }

    public void AddCategory(string categoryName)
    {
        throw new NotImplementedException();
    }

    public void AddCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void UpdateCategory(int categoryId)
    {
        var cat = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
        if (cat is not null)
        {
            _context.Categories.Update(cat);
            _context.SaveChanges();
        }
    }

    public void DeleteCategory(int categoryId)
    {
        var cat = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
        if (cat is not null)
        {
            _context.Categories.Remove(cat);
            _context.SaveChanges();
        }
    }

    public bool CategoryExists(int categoryId)
    {
        return _context.Categories.Any(c=>c.Id==categoryId);
    }
}