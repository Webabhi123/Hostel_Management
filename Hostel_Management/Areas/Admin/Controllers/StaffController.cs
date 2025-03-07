using Hostel_Management.DAL.Interface;
using Hostel_Management.DAL.Repository;
using Hostel_Management.EmailUtility;
using Hostel_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hostel_Management.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaffController : Controller
    {
        private IStaffRepository _staffRepository;
        private IMeetingRepository _meetingRepository;
        private IEmailService _emailService;
        public StaffController(IStaffRepository staffRepository,IMeetingRepository meetingRepository,IEmailService emailService)
        {
            _staffRepository = staffRepository;
            _meetingRepository = meetingRepository;
            _emailService = emailService;
        }
        public async Task<IActionResult> Index()
        {
            var staffuser = await _staffRepository.GetAll();
            return View(staffuser);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Staff entity)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userIdString, out var userId))
            {
                entity.UserId = userId; // Assign the parsed integer user ID
            }
            await _staffRepository.Add(entity);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var existinguser = await _staffRepository.GetById(id);
            if(existinguser != null)
            {
                return View(existinguser);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Staff entity)
        {
            if (ModelState.IsValid)
            {
                var isupdate= await _staffRepository.Update(entity);
                if(isupdate != null)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(entity);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var existuser = await _staffRepository.GetById(id);
            if (existuser != null)
            {
                await _staffRepository.Delete(id);
                TempData["SuccessMessage"] = "User deleted successfully.";
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "User not found.";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetMeetingInfo()
        {
            var meetings = await _meetingRepository.GetAll();
            return View(meetings);
        }
        public async Task<IActionResult> Send(int id)
        {
            var meetings = await _meetingRepository.GetById(id);
            if (meetings == null)
            {
                return NotFound();
            }
            string subject = "Meeting Notifcation";
            string body = $"Dear {meetings.Name},\n\nThis is a email regarding your meeting.You have schedule meeting{meetings.Date} we will contact for the meeting at this day.\n\nBest regards,\nTech Team";
            await _emailService.SendEmailAsync(meetings.Email, subject, body);

            return RedirectToAction("GetMeetingInfo");
        }
    }
}
