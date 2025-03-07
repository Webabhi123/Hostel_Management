using Hostel_Management.Models;

namespace Hostel_Management.DAL.Interface
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetAll();
        Task<Staff> Add(Staff entity);
        Task<bool> Update(Staff entity);
        Task<Staff> GetById(int id);
        Task<bool> Delete(int id);
        Task<int> TotalCount();
    }
}
