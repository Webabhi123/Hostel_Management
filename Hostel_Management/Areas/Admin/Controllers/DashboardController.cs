using Hostel_Management.Areas.Admin.ViewModel;
using Hostel_Management.Context;
using Hostel_Management.DAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hostel_Management.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private IStaffRepository _staffRepository;
        private IRoomRepository _roomRepository;
        private IMeetingRepository _meetingRepository;
        private IUserRepository _userRepository;
        public DashboardController(IStaffRepository staffRepository,IRoomRepository roomRepository,IMeetingRepository meetingRepository,IUserRepository userRepository) 
        { 
        _staffRepository = staffRepository;
        _roomRepository = roomRepository;
        _meetingRepository = meetingRepository;
        _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
            TotalRooms=await _roomRepository.TotalCount(),
            TotalStaff=await _staffRepository.TotalCount(),
            TotalUser=await _userRepository.TotalCount(),
            TotalMeeting=await _meetingRepository.TotalCount()
            };
            return View(model);
        }

        }
}
