using JobSeek.Data;
using JobSeek.Models;
using JobSeek.Services;
using JobSeek.Web.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobSeek.Controllers
{
    public class HomeController : Controller
    {
        private readonly LocationService _locationService;
        private readonly ListingService _listingService;
        public HomeController(LocationService locationService, ListingService listingService)
        {
            _locationService = locationService;
            _listingService = listingService;
        }
        public async Task<IActionResult> Index()
        {
            var listings = (await _listingService.GetJobListings()).Select(l => new ListingDTO
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

        public IActionResult About()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
