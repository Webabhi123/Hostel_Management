using Hostel_Management.Context;
using Hostel_Management.DAL.Interface;
using Hostel_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Hostel_Management.DAL.Repository
{
    public class RoomRepository:IRoomRepository
    {
        private ManagementDbcontext _context;

        public RoomRepository(ManagementDbcontext context) 
        { 
            _context = context;
        }
        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _context.Rooms.ToListAsync();
        }
        public async Task<Room> Add(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task<bool> Update(Room entity)
        {
            var existuser = await _context.Rooms.FindAsync(entity.RoomId);
            if (existuser != null)
            {
                existuser.RoomNumber = entity.RoomNumber;
                existuser.Capacity = entity.Capacity;
                existuser.IsOccupied = entity.IsOccupied;
                existuser.PricePerMonth = entity.PricePerMonth;
                //existuser.Description = entity.Description;
                existuser.RoomType = entity.RoomType;
                existuser.Image = entity.Image;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(int id)
        {
            var user = await _context.Rooms.FindAsync(id);
            if (user != null)
            {
                _context.Rooms.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task<Room> GetById(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<int> TotalCount()
        {
            return await _context.Rooms.CountAsync();
        }
    }
}
