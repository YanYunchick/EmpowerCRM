using EmpowerCRMv2.Models;

namespace EmpowerCRMv2.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContactItemsAsync();
        Task<Contact?> GetContactItemByIdAsync(int id);
        Task AddContactItemAsync(Contact item);
        Task UpdateContactItemAsync(Contact item);
        Task DeleteContactItemAsync(int id);
    }
}
