using WebApplication1.Models.Application.InfraStructor.DataAccess.Repositories;
using WebApplication1.Models.Application.InfraStructor.Interfaces;
using WebApplication1.Models.Application.InfraStructor.Interfaces.Services;
using WebApplication1.Models.Domain.Entities;

namespace WebApplication1.Models.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService()
    {
        _categoryRepository = new CategoryRepository();
    }
    public List<Category> GetAllCategories()
    {
        return _categoryRepository.getAllCategories();
    }

    public Category GetCategoryById(int categoryId)
    {
        return _categoryRepository.GetCategoryById(categoryId);
    }

    public void AddCategory(string name)
    {
        _categoryRepository.AddCategory(name);
    }

    public void UpdateCategory(int categoryId, string name)
    {
        _categoryRepository.UpdateCategory(categoryId,name);
    }

    public void DeleteCategory(int categoryId)
    {
        _categoryRepository.DeleteCategory(categoryId);

    }

    public Category? GetCategoryByName(string name)
    {
        return _categoryRepository.GetCategoryByName(name);
    }
}