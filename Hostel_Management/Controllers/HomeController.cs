using Hostel_Management.Context;
using Hostel_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hostel_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ManagementDbcontext _context;

        public HomeController(ManagementDbcontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Hotel")]
        public IActionResult Hotel()
        {
            return View();
        }
        [HttpGet]
        [Route("Schedule_Meeting")]
        public IActionResult Meeting()
        {
            return View();
        }
        [HttpPost]
        [Route("Schedule_Meeting")]
        public async Task<IActionResult> Meeting(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); // or another action if desired
            }
            return View(meeting);
        }
        [HttpGet]
        [Route("Event")]
        public IActionResult Event()
        {
            return View();
        }

        [HttpGet]
        [Route("About-us")]
        public IActionResult Aboutus()
        {
            return View();
        }
    }
}
