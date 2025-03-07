using Hostel_Management.Models;

namespace Hostel_Management.DAL.Interface
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAll();
        Task<Room> Add(Room room);
        Task<bool> Update(Room entity);
        Task<Room> GetById(int id);
        Task<bool> Delete(int id);
        Task<int> TotalCount();
    }
}
