using Hostel_Management.Models;

namespace Hostel_Management.DAL.Interface
{
    public interface IMeetingRepository
    {
        Task<Meeting> GetById(int id);
        Task<Meeting> Add(Meeting meeting);
        Task<IEnumerable<Meeting>> GetAll();
        Task<int> TotalCount();
    }
}
