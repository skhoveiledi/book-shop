using WebApplication1.Models.Application.InfraStructor.DataAccess.Repositories;
using WebApplication1.Models.Application.InfraStructor.Interfaces;
using WebApplication1.Models.Application.InfraStructor.Interfaces.Services;
using WebApplication1.Models.Domain.Entities;

namespace WebApplication1.Models.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService()
    {
        _userRepository = new UserRepository();
    }
    public List<User> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    public User? GetUserById(int userId)
    {
        return _userRepository.GetUserById(userId);
    }

    public void AddUser(User user)
    {
        _userRepository.AddUser(user);
    }

    public void UpdateUser(User user)
    {
        _userRepository.UpdateUser(user);
    }

    public void DeleteUser(int userId)
    {
        _userRepository.DeleteUser(userId);
    }

    public bool EmailExists(string email)
    {
       return _userRepository.UserExists(email);
    }

    public User? LoginUser(string email, string password)
    {
        return _userRepository.GetUser(email,password);
    }

    public bool ValidateUser(int userId)
    {
        throw new NotImplementedException();
    }
}