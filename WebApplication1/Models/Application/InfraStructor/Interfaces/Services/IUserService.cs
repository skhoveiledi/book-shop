using WebApplication1.Models.Domain.Entities;

namespace WebApplication1.Models.Application.InfraStructor.Interfaces.Services;

public interface IUserService
{
    List<User> GetAllUsers();
    User? GetUserById(int userId);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int userId);
    bool EmailExists(string email);
    User? LoginUser(string email, string password);
}