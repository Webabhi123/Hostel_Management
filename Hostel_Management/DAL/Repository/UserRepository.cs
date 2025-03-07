using Hostel_Management.Context;
using Hostel_Management.DAL.Interface;
using Hostel_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Hostel_Management.DAL.Repository
{
    public class UserRepository:IUserRepository
    {
        private ManagementDbcontext _context;

        public UserRepository(ManagementDbcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Add(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
        }
        public async Task<bool> Update(User entity)
        {
            var existinguser= await _context.Users.FindAsync(entity.Id);
            if(existinguser != null)
            {
                existinguser.UserName=entity.UserName;
                existinguser.UserEmail=entity.UserEmail;
                existinguser.Phonenumber=entity.Phonenumber;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(int id)
        {
            var user=await _context.Users.FindAsync(id);
            if(user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<int> TotalCount()
        {
            return await _context.Users.CountAsync();
        }
    }
}
