using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Application.InfraStructor.Interfaces.Services;
using WebApplication1.Models.Domain.Entities;
using WebApplication1.Models.Domain.Enums;
using WebApplication1.Models.Services;

namespace WebApplication1.Controllers
{
    public class AdminController:Controller
    {
        private readonly IUserService _userService = new UserService();
        private readonly ICategoryService _categoryService = new CategoryService();

        private List<RoleEnum> GetRoles()
        {
            return Enum.GetValues(typeof(RoleEnum)).Cast<RoleEnum>().ToList();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = _userService.GetAllUsers();
            ViewBag.Users = users;
            ViewBag.Roles = GetRoles();
            return View();
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            ViewBag.Roles = GetRoles();
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if(isn)
        }
    }
}
