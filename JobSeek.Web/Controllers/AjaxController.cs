using JobSeek.Data;
using JobSeek.Services;
using JobSeek.Web.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobSeek.Web.Controllers
{
    public class AjaxController : Controller
    {
        private readonly JobSeekDBContext _context;
        private readonly LocationService _locationService;
        public AjaxController(JobSeekDBContext jobSeekDBContext, LocationService locationService)
        {
            _context = jobSeekDBContext;
            _locationService = locationService;
        }

        public async Task<IActionResult> GetStatesByCountryID(int id)
        {
            List<StateDTO> states = (await _locationService.GetStatesByCountryID(id)).Select(s => new StateDTO(s)).OrderBy(s => s.Name).ToList();
            return Json(states);
        }
    }
}
