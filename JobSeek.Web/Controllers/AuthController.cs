using JobSeek.Data;
using JobSeek.Services;
using JobSeek.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobSeek.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly LocationService _locationService;
        private readonly UserService _userService;
        private readonly SignInManager<UserAccount> _signInManager;
        public AuthController(UserManager<UserAccount> userManager, LocationService locationService, UserService userService, SignInManager<UserAccount> signInManager)
        {
            _userManager = userManager;
            _locationService = locationService;
            _userService = userService;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Candidates" });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

        }
        public IActionResult Signup()
        {
            RegisterViewModel vm = new RegisterViewModel
            {
                Countries = _locationService.GetCountries(),
                UserAccountFormModel = new UserAccountFormModel()
                
            };
            return View(vm);
        }



        [HttpPost]
        public async Task<IActionResult> Signup(RegisterViewModel model)
        {
            model.Countries = _locationService.GetCountries();

            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }

            bool isValid = true;
            //Check if user exists
            if (_userService.UserEmailExists(model.UserAccountFormModel.Email))
            {
                isValid = false;
                ModelState.AddModelError("UserAccountFormModel.Email", "Email already exists");
            }

            //
            if ((!_locationService.IsValidState(model.UserAccountFormModel.CountryID, model.UserAccountFormModel.StateID, model.UserAccountFormModel.StateName)))
            {
                isValid = false;
                ModelState.AddModelError("UserAccountFormModel.StateName", "Not a valid state");
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

        public IActionResult SignOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                _signInManager.SignOutAsync();
            }
            return RedirectToAction("index", "Home");
        }
    }
}
