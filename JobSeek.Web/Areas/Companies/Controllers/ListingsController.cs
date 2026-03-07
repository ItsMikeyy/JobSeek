using Microsoft.AspNetCore.Mvc;

namespace JobSeek.Web.Areas.Companies.Controllers
{
    [Area("Companies")]
    public class ListingsController : Controller
    {

        public IActionResult Post()
        {
            return View();
        }
    }
}
