using WebApplication1.Models.Domain.Entities;

namespace WebApplication1.Models.Application.InfraStructor.Interfaces.Services;

public interface ICategoryService
{
    List<Category> GetAllCategories();
    Category GetCategoryById(int categoryId);
    void AddCategory(string name);
    void UpdateCategory(int categoryId);
    void DeleteCategory(int categoryId);
}