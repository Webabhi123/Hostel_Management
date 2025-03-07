using Hostel_Management.Context;
using Hostel_Management.DAL.Interface;
using Hostel_Management.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Security.Claims;

namespace Hostel_Management.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        //private readonly ManagementDbcontext _context;
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAll();
            return View(users);
        }

        [HttpGet]
        [Route("admin/user/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("admin/user/create")]
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
        //[Route("admin/login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[Route("admin/login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                // Assuming you have a method to verify the username and password
                var user = await _userRepository.GetByUsername(username);
                if (user != null)
                {
                    // Create the authentication ticket
                    var claims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name, username)
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    // Sign in the user by setting the cookie
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return View(); // Return back to the login form with an error message
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // Log out by clearing the cookie                                                                            
            return RedirectToAction("Index", "Home", new { area = "" }); // Redirect to the Index action of the HomeController outside the Admin area
        }
        public async Task<IActionResult> Edit(int id)
        {
            var existuser = await _userRepository.GetById(id);
            if (existuser != null)
            {
                return View(existuser);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _userRepository.Update(user);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(user); // Return the form with validation errors if any
        }

        public async Task<IActionResult> Delete(int id)
        {
            var existuser = await _userRepository.GetById(id);
            if (existuser != null)
            {
                await _userRepository.Delete(id);
                TempData["SuccessMessage"] = "User deleted successfully.";
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "User not found.";
            return RedirectToAction("Index");
        }
    }
}
