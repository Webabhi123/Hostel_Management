using Hostel_Management.Models;

namespace Hostel_Management.DAL.Interface
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> Add(Contact entity);
    }
}
