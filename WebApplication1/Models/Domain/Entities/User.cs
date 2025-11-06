using WebApplication1.Models.Domain.Enums;

namespace WebApplication1.Models.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public RoleEnum Role { get; set; }
}