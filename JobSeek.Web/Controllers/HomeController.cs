using JobSeek.Data;
using JobSeek.Models;
using JobSeek.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using JobSeek.Data;
using JobSeek.Services;

namespace JobSeek.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobSeekDBContext _context;
        private readonly UserManager<UserAccount> _userManager;
        private readonly LocationService _locationService;


        public HomeController(JobSeekDBContext context, UserManager<UserAccount> userManager, LocationService locationService)
        {
            _context = context;
            _userManager = userManager;
            _locationService = locationService;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }

        public IActionResult AuthorizeEmail(EmailInputModel model)
        {
            RegisterViewModel userModel = new RegisterViewModel
            {
                UserAccountFormModel = new UserAccountFormModel { Email = model.Email },
            };
            return RedirectToAction("Register", model);
        }

        public IActionResult Register(RegisterViewModel model)
        {
            model.Countries = _locationService.GetCountries();

            return View(model);
        }
        [HttpPost]
        public IActionResult AuthorizeAccount(RegisterViewModel model)
        {
            ModelState.Remove("Countries");
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Register", model);
            }      

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
