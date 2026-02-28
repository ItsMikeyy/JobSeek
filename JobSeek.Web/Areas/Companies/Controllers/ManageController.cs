using JobSeek.Data;
using JobSeek.Services;
using JobSeek.Web.Areas.Companies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobSeek.Web.Areas.Companies.Controllers
{
    [Area("Companies")]
    public class ManageController : Controller
    {
        private readonly UserService _userService;
        private readonly UserManager<UserAccount> _userManager;
        private readonly JobSeekDBContext _jobSeekDBContext;
        private readonly CompanyService _companyService;
        public ManageController(UserManager<UserAccount> userManager, UserService userService, JobSeekDBContext jobSeekDBContext, CompanyService companyService) 
        {
            _userManager = userManager;
            _userService = userService;
            _jobSeekDBContext = jobSeekDBContext;
            _companyService = companyService;
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Challenge();
            }

            if (_companyService.GetCompanyByUserCompanyID(user.CompanyID.Value) != null) 
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyModel model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Company company = new Company
            {
                CompanyName = model.CompanyName,
                Website = model.Website,
                Description = model.Description
            };
            _jobSeekDBContext.Add(company);
            _userService.AddUserCompany(company, user);

            return View();
        }
    }
}
