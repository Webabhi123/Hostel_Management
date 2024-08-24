using Hostel_Management.Context;
using Hostel_Management.DAL.Interface;
using Hostel_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using Stripe.Checkout;

namespace Hostel_Management.Controllers
{
    public class HomeController : Controller
    {
        private IMeetingRepository _meetingRepository;

        public HomeController(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
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
                await _meetingRepository.Add(meeting);
                return RedirectToAction("Index", "Home"); // or another action if desired
            }
            return View(meeting);
        }
        [HttpGet]
        [Route("Event-Management")]
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

        [HttpGet]
        [Route("Club-Management")]
        public IActionResult Club()
        {
            return View();
        }

        [HttpGet]
        [Route("Pricing")]
        public IActionResult Pricing()
        {
            return View();
        }



        [Route("CheckOut")]
        public IActionResult CheckOut(string planName, long price)
        {
            var domain = "https://localhost:7199/";

            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + "CheckOut/OrderConfirmation",
                CancelUrl = domain + "CheckOut/Login",
                LineItems = new List<SessionLineItemOptions>
            {
            new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "INR",
                    UnitAmount = 50000, // Convert price to smallest currency unit (e.g., paise for INR)
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = "Hostel Booking", // Use the plan name from the form
                    },
                },
                Quantity = 1,
            },
            },
                Mode = "payment",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303); // Stripe uses 303 redirect for Checkout sessions
        }

    }
}
