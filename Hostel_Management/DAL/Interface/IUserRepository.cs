using Hostel_Management.Models;

namespace Hostel_Management.DAL.Interface
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        Task<User> GetByUsername(string username);
    }
}
