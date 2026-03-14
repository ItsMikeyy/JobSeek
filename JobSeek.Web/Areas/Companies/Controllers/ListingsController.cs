using JobSeek.Data;
using JobSeek.Services;
using JobSeek.Web.Areas.Companies.Models;
using JobSeek.Web.Areas.Companies.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobSeek.Web.Areas.Companies.Controllers
{
    [Area("Companies")]
    public class ListingsController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly LocationService _locationService;
        private readonly ListingService _listingService;
        private readonly CompanyService _companyService;
        private readonly UserService _userService;

        public ListingsController(LocationService locationService, ListingService listingService, CompanyService companyService, UserManager<UserAccount> userManager, UserService userService) 
        {
            _userManager = userManager;
            _locationService = locationService;
            _listingService = listingService;
            _companyService = companyService;
            _userService = userService;
        }

        [Authorize]
        public async Task<IActionResult> Post()
        {
            var user = await _userService.GetUserByEmail(User.Identity.Name);
            if (user?.CompanyID == null || user?.Company == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Countries = _locationService.GetCountries();
            ViewBag.JobType = ParseEnum<JobType>();
            ViewBag.SalaryType = ParseEnum<SalaryType>();
            ViewBag.WorkArrangement = ParseEnum<WorkArrangement>();

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(JobListingModel model)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Countries = _locationService.GetCountries();
                ViewBag.JobType = ParseEnum<JobType>();
                ViewBag.SalaryType = ParseEnum<SalaryType>();
                ViewBag.WorkArrangement = ParseEnum<WorkArrangement>();
                return View(model);
            }

            var user = await _userService.GetUserByEmail(User.Identity.Name);
            if (user?.CompanyID == null || user?.Company == null)
            {
                return RedirectToAction("Index", "Home");
            }

            JobListing listing = new JobListing
            {
                Title = model.Title,
                Description = model.Description,
                CountryID = model.CountryID,
                StateID = model.StateID,
                StateName = model.StateName,
                City = model.City,
                WorkArrangement = model.WorkArrangement,
                Salary = model.Salary,
                SalaryMin = model.SalaryMin,
                SalaryMax = model.SalaryMax,
                SalaryType = model.SalaryType,
                JobType = model.JobType,
                PostedAt = DateTime.Now,
                ExpiresAt = model.ExpiresAt,
                IsActive = model.IsActive,
                IsPublic = model.IsPublic,
                CompanyID = user.CompanyID.Value,
                Employer = user.Company,
                
            };

            State? state = await _locationService.GetStateByStateID(model.StateID);
            Country? country = await _locationService.GetCountryByID(model.CountryID);

            if (country == null || (state == null && model.StateID != null))
            {
                //Return fail
            }

            listing.Country = country;
            listing.State = state;

            var success = await _listingService.AddJobListing(listing, user.Company);

            if (!success)
            {
                //Redirect to a fail page or maybe a modal should appear ?
            }
            //Eventually redirect to the listing page
            return View();
        }

        private Dictionary<int, string> ParseEnum<TEnum>() where TEnum : struct, Enum
        {
            return Enum.GetValues<TEnum>()
                       .ToDictionary(v => Convert.ToInt32(v), v => v.ToString());
        }

    }
}
