using Hostel_Management.Context;
using Hostel_Management.DAL.Interface;
using Hostel_Management.Models;

namespace Hostel_Management.DAL.Repository
{
    public class MeetingRepository : IMeetingRepository
    {
        private ManagementDbcontext context;
        public MeetingRepository(ManagementDbcontext _context)
        {
            context = _context;
        }

        public async Task<Meeting> Add(Meeting meeting)
        {
            // Implementation of the method
            // For example:
            await context.AddAsync(meeting);
            // await _context.SaveChangesAsync();
            return meeting;
        }
    }
}
