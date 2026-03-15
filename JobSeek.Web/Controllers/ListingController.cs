using JobSeek.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobSeek.Web.Controllers
{
    [Route("listing")]
    public class ListingController : Controller
    {
        private readonly ListingService _listingService;
        public ListingController(ListingService listingService) 
        {
            _listingService = listingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var listing = await _listingService.GetJobListingByID(id);

            if (listing == null)
            {
                //Redirect to listing not found
            }

            return View(listing);

        }
    }
}
