using WebApplication1.Models.Domain.Entities;
using WebApplication1.Models.Domain.Enums;

namespace WebApplication1.Models.ViewModels
{
    public class UsersViewModel
    {
        public List<User> Users { get; set; } = new();
        public List<RoleEnum> Roles { get; set; }  = new();
    }
}
