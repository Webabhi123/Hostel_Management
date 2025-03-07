using Hostel_Management.Models;

namespace Hostel_Management.DAL.Interface
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        Task<User> GetByUsername(string username);

        Task<IEnumerable<User>> GetAll();
        Task<bool> Update(User user); 
        Task<bool> Delete(int id);
        Task<User> GetById(int id);
        Task<int> TotalCount();
    }
}
