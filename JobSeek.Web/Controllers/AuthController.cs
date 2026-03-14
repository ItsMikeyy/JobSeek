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
            ViewBag.Countries = _locationService.GetCountries();            
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Signup(UserAccountFormModel model)
        {
            ViewBag.Countries = _locationService.GetCountries();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isValid = true;
            //Check if user exists
            if (await _userService.UserEmailExists(model.Email))
            {
                isValid = false;
                ModelState.AddModelError("Email", "Email already exists");
            }

            //
            if ((!await _locationService.IsValidState(model.CountryID, model.StateID, model.StateName)))
            {
                isValid = false;
                ModelState.AddModelError("StateName", "Not a valid state");
            }

            if (!isValid) return View(model);


            var user = new UserAccount
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                CountryID = model.CountryID,
                StateID = model.StateID,
                StateName = model.StateName,
                City = model.City,
                DateOfBirth = model.DateOfBirth,
                ZipCode = model.ZipCode,
            };

            //var result = await _userManager.CreateAsync(user, model.Password);

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
