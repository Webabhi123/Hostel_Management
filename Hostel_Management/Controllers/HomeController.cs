using Microsoft.AspNetCore.Mvc;

namespace Hostel_Management.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("Hotel")]
        public IActionResult Hotel()
        {
            return View();
        }
        [Route("Schedule_Meeting")]
        public IActionResult Meeting()
        {
            return View();
        }
    }
}
