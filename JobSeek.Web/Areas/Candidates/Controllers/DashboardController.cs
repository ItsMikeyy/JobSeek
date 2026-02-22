using JobSeek.Data;
using JobSeek.Services;
using JobSeek.Web.Areas.Candidates.Models;
using JobSeek.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobSeek.Web.Areas.Users.Controllers
{
    [Area("Candidates")]
    public class DashboardController : Controller
    {
        private readonly UserService _userService;
        private readonly UserManager<UserAccount> _userManager;

        public DashboardController(UserService userService, UserManager<UserAccount> userManager) 
        { 
            _userService = userService;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            UserAccount? user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            DashboardViewModel vm = new DashboardViewModel
            {
                User = new UserDTO(user)
            };
            return View(vm);
        }
    }
}
