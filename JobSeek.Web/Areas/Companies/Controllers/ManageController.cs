using JobSeek.Data;
using JobSeek.Web.Areas.Companies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobSeek.Web.Areas.Companies.Controllers
{
    [Area("Companies")]
    public class ManageController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        public ManageController(UserManager<UserAccount> userManager) 
        {
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);


            if (user.Company != null) 
            { 
                //redirect
            }

            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCompanyModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View();
        }
    }
}
