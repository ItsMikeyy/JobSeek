using JobSeek.Data;
using JobSeek.Models;
using JobSeek.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using JobSeek.Data;
using JobSeek.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JobSeek.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobSeekDBContext _context;
        private readonly UserManager<UserAccount> _userManager;
        private readonly LocationService _locationService;
        private readonly UserService _userService;


        public HomeController(JobSeekDBContext context, UserManager<UserAccount> userManager, LocationService locationService, UserService userService)
        {
            _context = context;
            _userManager = userManager;
            _locationService = locationService;
            _userService = userService;
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

        public IActionResult Register(EmailInputModel model)
        {
            RegisterViewModel rvm = new RegisterViewModel
            {
                Countries = _locationService.GetCountries(),
                UserAccountFormModel = new UserAccountFormModel
                {
                    Email = model.Email
                }
            };

            return View(rvm);
        }
        
        [HttpPost]
        public async Task<IActionResult> AuthorizeAccount(RegisterViewModel model)
        {        
            model.Countries = _locationService.GetCountries();

            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }

            bool isValid = true;

            if (_userService.UserEmailExists(model.UserAccountFormModel.Email))
            {
                isValid = false;
                ModelState.AddModelError("UserAccountFormModel.Email", "Email already exists");
            }
            model.UserAccountFormModel.StateName = "jmasdkljaskl";
            if ((!_locationService.IsValidState(model.UserAccountFormModel.CountryID, model.UserAccountFormModel.StateID, model.UserAccountFormModel.StateName)))
            {
                isValid = false;
                ModelState.AddModelError("UserAccountFormModel.State", "Not a valid state");
            }

            if (!isValid) return View("Register", model);


            var user = new UserAccount
            {
                FirstName = model.UserAccountFormModel.FirstName,
                LastName = model.UserAccountFormModel.LastName,
                Email = model.UserAccountFormModel.Email,
                UserName = model.UserAccountFormModel.Email,
                CountryID = model.UserAccountFormModel.CountryID,
                StateID = model.UserAccountFormModel.StateID,
                StateName = model.UserAccountFormModel.StateName,
                City = model.UserAccountFormModel.City,
                DateOfBirth = model.UserAccountFormModel.DateOfBirth,
                ZipCode = model.UserAccountFormModel.ZipCode,
            };

            //var result = await _userManager.CreateAsync(user, model.UserAccountFormModel.Password);

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
