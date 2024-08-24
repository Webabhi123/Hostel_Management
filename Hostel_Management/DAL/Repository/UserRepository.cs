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

        public async Task<User> Add(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> GetByUsername(string username)
        {
            return await _context.users.FirstOrDefaultAsync(x => x.UserName == username);
        }
    }
}
