using WebApplication1.Models.Domain.Entities;
using WebApplication1.Models.Domain.Enums;

namespace WebApplication1.Models.Config
{
    public class CurrentUser
    {
        private static User? _currentUser = null;
      
        public static void Login(User user)
        {
            _currentUser = user;
        }

        public static void Logout()
        {
            _currentUser = null;
        }

        public static User? GetCurrentUser()
        {
            return _currentUser;
        }

        public static bool IsALoggedIn()
        {
            return _currentUser != null;
        }

        public static bool IsAdmin()
        {
            return _currentUser !=null && _currentUser.Role == RoleEnum.Admin;
        }

        public static int? GetUserId()
        {
            return _currentUser?.Id;
        }

        public static string GetUserName()
        {
            return _currentUser?.Name;
        }
    }
}
