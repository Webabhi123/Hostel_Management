using Hostel_Management.Context;
using Hostel_Management.DAL.Interface;
using Hostel_Management.Models;

namespace Hostel_Management.DAL.Repository
{
    public class MeetingRepository : IMeetingRepository
    {
        private ManagementDbcontext _context;
        public MeetingRepository(ManagementDbcontext context)
        {
            _context = context;
        }

        public async Task<Meeting> Add(Meeting meeting)
        {
            // Implementation of the method
            // For example:
            await _context.AddAsync(meeting);
            await _context.SaveChangesAsync();
            return meeting;
        }
    }
}
