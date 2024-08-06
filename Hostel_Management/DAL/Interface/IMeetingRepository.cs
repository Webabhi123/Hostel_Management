using Hostel_Management.Models;

namespace Hostel_Management.DAL.Interface
{
    public interface IMeetingRepository
    {
        Task<Meeting> Add(Meeting meeting);
    }
}
