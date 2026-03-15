using JobSeek.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JobSeek.Web.Models.DTO;


namespace JobSeek.Web.Areas.Companies.Controllers
{
    [Area("Companies")]
    public class DashboardController : Controller
    {
        private readonly LocationService _locationService;
        private readonly ListingService _ListingService;
        private readonly UserService _userService;
        public DashboardController(LocationService locationService, ListingService listingService, UserService userService)
        {
            _userService = userService;
            _locationService = locationService;
            _ListingService = listingService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserByEmail(User.Identity?.Name);
            var listings = user.Company.JobListings.Select(l => new ListingDTO
            {
                JobID = l.JobID,
                Title = l.Title,
                Description = l.Description,
                Country = l.Country,
                State = l.State,
                StateName = l.StateName,
                Salary = l.Salary,
                SalaryMin = l.SalaryMin,
                SalaryMax = l.SalaryMax,
                City = l.City,
                Company = l.Company
            }).ToList();

            return View(listings);
        }
    }
}
