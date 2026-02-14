using JobSeek.Data;
using JobSeek.Models;
using JobSeek.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using JobSeek.Data;

namespace JobSeek.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobSeekDBContext _context;
        private readonly UserManager<UserAccount> _userManager;

        public HomeController(JobSeekDBContext context, UserManager<UserAccount> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            UserAccountFormModel userModel = new UserAccountFormModel
            {
                Email = model.Email,
            };
            return RedirectToAction("Register", model);
        }

        public IActionResult Register(UserAccountFormModel model)
        {
            
            return View(model);
        }
        [HttpPost]
        public IActionResult AuthorizeAccount(UserAccountFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Register", model);
            }

            var user = new UserAccount
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CountryID = model.CountryID,
                StateID = model.StateID,
                CityID = model.CityID,
                DateOfBirth = model.DateOfBirth,
                ZipCode = model.ZipCode,

            };


            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
