using Hostel_Management.DAL.Interface;
using Hostel_Management.DAL.Repository;
using Hostel_Management.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Hostel_Management.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        private IRoomRepository _roomRepository;
        private IUserRepository _userRepository;

        public RoomController(IRoomRepository roomRepository, IUserRepository userRepository)
        {
            _roomRepository = roomRepository;
            _userRepository = userRepository;
         
        }
        public async Task<IActionResult> Index()
        {
            var rooms=await _roomRepository.GetAll();
            return View(rooms);
        }
        [Route("Admin/Room/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Admin/Room/Create")]
        public async Task<IActionResult> Create(Room room, IFormFile imageFile)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (imageFile != null)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageFile.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    room.Image = $"/images/{imageFile.FileName}";
                }
            // Parse the user ID to an integer
            if (int.TryParse(userIdString, out var userId))
            {
                room.UserId = userId; // Assign the parsed integer user ID
            }
            _roomRepository.Add(room);
                return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var existinguser = await _roomRepository.GetById(id);
            if (existinguser != null)
            {
                return View(existinguser);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Room entity,IFormFile imageFile)
        {
            if (imageFile != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                entity.Image = $"/images/{imageFile.FileName}";
            }
            _roomRepository.Update(entity);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var existuser = await _roomRepository.GetById(id);
            if (existuser != null)
            {
                await _roomRepository.Delete(id);
                TempData["SuccessMessage"] = "User deleted successfully.";
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "User not found.";
            return RedirectToAction("Index");
        }


    }
}
