using Hostel_Management.Context;
using Hostel_Management.DAL.Interface;
using Hostel_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hostel_Management.Controllers
{
    public class UserController : Controller
    {
        //private readonly ManagementDbcontext _context;
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("admin/create/user")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("admin/create/user")]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.Add(user);
                // Redirect to login and pass the newly created user's ID as a query parameter
                return RedirectToAction("Login", "User");
            }
            return View();
        }


        [HttpGet]
        [Route("admin/login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("admin/login")]
        public async Task<IActionResult> Login(int id,string username)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the user by ID
                var user = await _userRepository.GetByUsername(username);
                if(user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}
