using Hostel_Management.Context;
using Hostel_Management.DAL.Interface;
using Hostel_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Hostel_Management.DAL.Repository
{
    public class StaffRepository:IStaffRepository
    {
        private ManagementDbcontext _context;
        public StaffRepository(ManagementDbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Staff>> GetAll()
        {
            return await _context.Staffs.ToListAsync();
        }
        public async Task<Staff> Add(Staff entity)
        {
            await _context.Staffs.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> Update(Staff entity)
        {
            var existuser = await _context.Staffs.FindAsync(entity.StaffId);
            if(existuser != null)
            {
                existuser.Name=entity.Name;
                existuser.PhoneNumber=entity.PhoneNumber;
                existuser.Email=entity.Email;
                existuser.Address = entity.Address;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(int id)
        {
            var user = await _context.Staffs.FindAsync(id);
            if (user != null)
            {
                _context.Staffs.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task<Staff> GetById(int id)
        {
            return await _context.Staffs.FindAsync(id);
        }
        public async Task<int> TotalCount()
        {
            return await _context.Staffs.CountAsync();
        }
    }
}
