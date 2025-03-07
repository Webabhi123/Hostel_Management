using Hostel_Management.DAL.Interface;
using Hostel_Management.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace Hostel_Management.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private IRoomRepository _roomRepository;
        private IContactRepository _contactRepository;
        private IMeetingRepository _meetingRepository;
        private IStaffRepository _staffRepository;
        public ReportController(IRoomRepository roomRepository, IContactRepository contactRepository, IMeetingRepository meetingRepository, IStaffRepository staffRepository)
        {
            _roomRepository = roomRepository;
            _contactRepository = contactRepository;
            _meetingRepository = meetingRepository;
            _staffRepository = staffRepository;
        }
        public async Task<IActionResult> RoomReport()
        {
            var rooms = await _roomRepository.GetAll();
            return View(rooms);
        }
        public async Task<IActionResult> ContactReport()
        {
            var contacts = await _contactRepository.GetAll();
            return View(contacts);
        }
        public async Task<IActionResult> MeetingReport()
        {
            var meetings = await _meetingRepository.GetAll();
            return View(meetings);
        }
        public async Task<IActionResult> StaffReport()
        {
            var staffs = await _staffRepository.GetAll();
            return View(staffs);
        }
        public async Task<IActionResult> ExportRoomReport()
        {
            var rooms = await _roomRepository.GetAll();
            //var staffs =await _staffRepository.GetAll();
            //var meetings = _meetingRepository.GetAll();

            using (var package = new ExcelPackage())
            {
                var roomSheet = package.Workbook.Worksheets.Add("Rooms");
                roomSheet.Cells["A1"].Value = "RoomId";
                roomSheet.Cells["B1"].Value = "RoomNumber";
                roomSheet.Cells["C1"].Value = "PricePerMonth";
                roomSheet.Cells["D1"].Value = "IsOccupied";
                //var workSheet = package.Workbook.Worksheets.Add("Rooms");
                int row = 2;
                foreach (var room in rooms)
                {
                    roomSheet.Cells[row, 1].Value = room.RoomId;
                    roomSheet.Cells[row, 2].Value = room.RoomNumber;
                    roomSheet.Cells[row, 3].Value = room.PricePerMonth;
                    roomSheet.Cells[row, 4].Value = room.IsOccupied ? "Yes" : "No";
                    row++;
                }
                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;
                string excelName = $"Report-{DateTime.Now:yyyyMMddHHmmssfff}.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                
            }
        }

        public async Task<IActionResult> ExportContactReport()
        {
            var model = await _contactRepository.GetAll();
            //var staffs =await _staffRepository.GetAll();
            //var meetings = _meetingRepository.GetAll();

            using (var package = new ExcelPackage())
            {
                var roomSheet = package.Workbook.Worksheets.Add("Contact_List");
                roomSheet.Cells["A1"].Value = "Name of the person";
                roomSheet.Cells["B1"].Value = "Email";
                roomSheet.Cells["C1"].Value = "Message";
                
                //var workSheet = package.Workbook.Worksheets.Add("Rooms");
                int row = 2;
                foreach (var item in model)
                {
                    roomSheet.Cells[row, 1].Value = item.Name;
                    roomSheet.Cells[row, 2].Value = item.Email;
                    roomSheet.Cells[row, 3].Value = item.Message;
                    row++;
                }
                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;
                string excelName = $"Report-{DateTime.Now:yyyyMMddHHmmssfff}.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                
            }
        }

        public async Task<IActionResult> ExportMeetingReport()
        {
            var model = await _meetingRepository.GetAll();
            //var staffs =await _staffRepository.GetAll();
            //var meetings = _meetingRepository.GetAll();

            using (var package = new ExcelPackage())
            {
                var roomSheet = package.Workbook.Worksheets.Add("Meetings");
                roomSheet.Cells["A1"].Value = "Name of the person";
                roomSheet.Cells["B1"].Value = "Email";
                roomSheet.Cells["C1"].Value = "Address";
                roomSheet.Cells["D1"].Value = "Phonenumber";
                roomSheet.Cells["E1"].Value = "City";
                //var workSheet = package.Workbook.Worksheets.Add("Rooms");
                int row = 2;
                foreach (var item in model)
                {
                    roomSheet.Cells[row, 1].Value = item.Name;
                    roomSheet.Cells[row, 2].Value = item.Email;
                    roomSheet.Cells[row, 3].Value = item.Address;
                    roomSheet.Cells[row, 4].Value = item.PhoneNumber;
                    roomSheet.Cells[row, 5].Value = item.City;
                    row++;
                }
                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;
                string excelName = $"Report-{DateTime.Now:yyyyMMddHHmmssfff}.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                
            }
        }
        public async Task<IActionResult> ExportStaffReport()
        {
            var model = await _staffRepository.GetAll();
            //var staffs =await _staffRepository.GetAll();
            //var meetings = _meetingRepository.GetAll();

            using (var package = new ExcelPackage())
            {
                var roomSheet = package.Workbook.Worksheets.Add("Staffs");
                roomSheet.Cells["A1"].Value = "Name of the Staff";
                roomSheet.Cells["B1"].Value = "PhoneNumber";
                roomSheet.Cells["C1"].Value = "Email";
                roomSheet.Cells["D1"].Value = "Address";
                //var workSheet = package.Workbook.Worksheets.Add("Rooms");
                int row = 2;
                foreach (var item in model)
                {
                    roomSheet.Cells[row, 1].Value = item.Name;
                    roomSheet.Cells[row, 2].Value = item.PhoneNumber;
                    roomSheet.Cells[row, 3].Value = item.Email;
                    roomSheet.Cells[row, 4].Value = item.Address;
                    row++;
                }
                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;
                string excelName = $"Report-{DateTime.Now:yyyyMMddHHmmssfff}.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                
            }
        }
    }
}
