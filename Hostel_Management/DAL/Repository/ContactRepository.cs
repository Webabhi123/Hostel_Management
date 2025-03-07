using Hostel_Management.Context;
using Hostel_Management.DAL.Interface;
using Hostel_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Hostel_Management.DAL.Repository
{
    public class ContactRepository:IContactRepository
    {
        private ManagementDbcontext _context;

        public ContactRepository(ManagementDbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }
        public async Task<Contact> Add(Contact entity)
        {
            await _context.Contacts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}
