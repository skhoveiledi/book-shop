using WebApplication1.Models.Domain.Entities;

namespace WebApplication1.Models.Application.InfraStructor.Interfaces;

public interface ICategoryRepository
{
    List<Category> getAllCategories();
    Category? GetCategoryById(int id);
    void AddCategory(string categoryName);
    void UpdateCategory(int categoryId);
    void DeleteCategory(int categoryId);
    bool CategoryExists(int categoryId);
}