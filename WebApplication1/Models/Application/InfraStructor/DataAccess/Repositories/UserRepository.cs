using WebApplication1.Models.Application.InfraStructor.Interfaces;
using WebApplication1.Models.Config;
using WebApplication1.Models.Domain.Entities;

namespace WebApplication1.Models.Application.InfraStructor.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository()
    {
        _context = new AppDbContext();
    }
    public List<User> GetAllUsers()
    {
        return _context.Users
            .OrderByDescending(u => u.Name)
            .ToList();
    }

    public User? GetUserById(int userId)
    {
        return _context.Users.FirstOrDefault(u => u.Id == userId);
    }

    public User? GetUser(string email, string password)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        //_context.Update(user);
        var findUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
        if (findUser != null)
        {
            findUser.Name = user.Name;
            findUser.Email = user.Email;
            findUser.Password = user.Password;
            findUser.Role = user.Role;
            _context.SaveChanges();

        }


    }

    public void DeleteUser(int userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

    public User? GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    public bool UserExists(string email)
    {
        return _context.Users.Any(u => u.Email == email);
    }
}