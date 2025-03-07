using Hostel_Management.DAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hostel_Management.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<IActionResult> Index()
        {
            var ContactList=await _contactRepository.GetAll();
            return View(ContactList);
        }
    }
}
