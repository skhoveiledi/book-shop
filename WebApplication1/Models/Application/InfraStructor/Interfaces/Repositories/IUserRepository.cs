using WebApplication1.Models.Domain.Entities;

namespace WebApplication1.Models.Application.InfraStructor.Interfaces;

public interface IUserRepository
{
    List<User> GetAllUsers();
    User? GetUserById(int userId);
    User? GetUser(string email, string password);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int userId);
    User? GetUserByEmail(string email);
    bool UserExists(string email);

}