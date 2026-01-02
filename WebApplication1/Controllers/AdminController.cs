using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Application.InfraStructor.Interfaces.Services;
using WebApplication1.Models.Config;
using WebApplication1.Models.Domain.Entities;
using WebApplication1.Models.Domain.Enums;
using WebApplication1.Models.Services;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class AdminController:Controller
    {
        private readonly IUserService _userService = new UserService();
        private readonly ICategoryService _categoryService = new CategoryService();

        //private bool IsAdminLoggedIn()
        //{
        //    var userRole = HttpContext.Session.GetString("UserRole");
        //    return userRole == RoleEnum.Admin.ToString();
        //}

        //private int? GetCurrentUserId()
        //{
        //    var userId = HttpContext.Session.GetString("UserId");
        //    if(int.TryParse(userId, out int uid))
        //        return uid;
        //    return null;
        //}

        //private IActionResult CheckAdminAccess()
        //{
        //    if (!IsAdminLoggedIn())
        //        return RedirectToAction("Login", "User");
        //    return null;
        //}
        public IActionResult CheckAdminAccess()
        {
            if (!CurrentUser.IsAdmin())
            {
                return RedirectToAction("Login", "User");
            }

            return null;
        }
        private List<RoleEnum> GetRoles()
        {
            return Enum.GetValues(typeof(RoleEnum)).Cast<RoleEnum>().ToList();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var check = CheckAdminAccess();
            if (check is not null)
            {
                return check;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Users()
        {
            var check = CheckAdminAccess();
            if (check is not null)
                return check;
            var users = _userService.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            var check = CheckAdminAccess();
            if (check is not null)
            {
                return check;
            }
            var adduser = new UserViewModel
            {
                Roles = GetRoles()
            };
            return View(adduser);
        }

        [HttpPost]
        public IActionResult AddUser(UserViewModel user)
        {
            var check = CheckAdminAccess();
            if (check is not null)
            {
                return check;
            }
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Name) ||
                string.IsNullOrEmpty(user.Password))
            {
                user.Roles = GetRoles();
                user.Message = "fill all fields";
                return View(user);
            }

            if (_userService.EmailExists(user.Email))
            {
                user.Roles = GetRoles();
                user.Message = "user exists try to login.";
                return View(user);
            }

            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                CreatedAt = DateTime.Now
            };
            _userService.AddUser(newUser);
            return RedirectToAction("Users");

        }

        [HttpGet]
        public IActionResult EditUser(int userId)
        {
            var check = CheckAdminAccess();
            if (check is not null)
                return check;
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return RedirectToAction("Users");
            }

            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = "",
                Roles = GetRoles(),
                Role = user.Role
            };
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult EditUser(UserViewModel userViewModel)
        {
            var check = CheckAdminAccess();
            if (check is not null)
                return check;
            if (string.IsNullOrEmpty(userViewModel.Email) || string.IsNullOrEmpty(userViewModel.Name) ||
                string.IsNullOrEmpty(userViewModel.Password))
            {
                userViewModel.Roles = GetRoles();
                userViewModel.Message = "fill all fields";
                return View(userViewModel);
            }

            var userExists = _userService.GetUserById(userViewModel.Id);
            if (userExists is null)
            {
                return RedirectToAction("Users");
            }

            if (userExists.Email != userViewModel.Email)
            {
                userViewModel.Roles = GetRoles();
                userViewModel.Message = "email already exists.use another email";
                return View(userViewModel);
            }

            var user = new User
            {
                Id = userViewModel.Id,
                Name = userViewModel.Name,
                Email = userViewModel.Email,
                Password = userViewModel.Password,
                Role = userViewModel.Role,
                CreatedAt = userExists.CreatedAt
            };
            _userService.UpdateUser(user);
            return RedirectToAction("Users");

        }

        [HttpPost]
        public IActionResult DeleteUser(int userId)
        {
            var check = CheckAdminAccess();
            if (check is not null)
            {
                return check;
            }
            _userService.DeleteUser(userId);
            return RedirectToAction("Users");
        }

        [HttpGet]
        public IActionResult Categories()
        {
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ViewBag.Error = "enter category name";
                return View();
            }

            _categoryService.AddCategory(name);
            return RedirectToAction("Categories");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category is null)
            {
                return RedirectToAction("Categories");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategory(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ViewBag.Error = "enter category name";
                return View();
            }

            var category = _categoryService.GetCategoryByName(name);
            _categoryService.UpdateCategory(category.Id,name);
            return RedirectToAction("Categories");

        }
        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
            return RedirectToAction("Categories");
        }
    }
}
