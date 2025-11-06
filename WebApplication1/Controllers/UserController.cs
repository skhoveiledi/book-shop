using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Application.InfraStructor.Interfaces.Services;
using WebApplication1.Models.Domain.Entities;
using WebApplication1.Models.Domain.Enums;
using WebApplication1.Models.Services;

namespace WebApplication1.Controllers
{
    public class UserController:Controller
    {
        private readonly IUserService _userService = new UserService();

        private List<RoleEnum> GetRoles()
        {
            return Enum.GetValues(typeof(RoleEnum)).Cast<RoleEnum>().ToList();
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Please enter email and password.";
                return View();
            }

            var user = _userService.LoginUser(email, password);
            if (user is null)
            {
                ViewBag.Error = "Invalid Email or Password.";
                return View();
            }
            //HttpContext.Session.SetString("UserId", user.Id.ToString());

            if (user.Role == RoleEnum.Admin)
                return RedirectToAction("Index", "Admin");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = GetRoles();
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Password))
            {
                ViewBag.Error = "fill all fields";
                ViewBag.Roles = GetRoles();
                return View();
            }

            if (_userService.EmailExists(user.Email))
            {
                ViewBag.Error = "You have already registered try to login.";
                ViewBag.Roles = GetRoles();
                return View();
            }

            user.CreatedAt = DateTime.Now;
            _userService.AddUser(user);
            ViewBag.SuccesMessage = "Registration successful.Try to login";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            //HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }

    }
}
