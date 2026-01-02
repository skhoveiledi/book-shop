using WebApplication1.Models.Domain.Enums;

namespace WebApplication1.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get;set; }
        public RoleEnum Role { get;set; }
        public List<RoleEnum> Roles { get; set; } = new();
        public string? Message { get; set; }
    }
}
