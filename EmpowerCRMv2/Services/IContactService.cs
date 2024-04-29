using EmpowerCRMv2.Models;

namespace EmpowerCRMv2.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllItemsAsync();
        Task<Contact> GetContactItemByIdAsync(int id);
        Task AddContactItemAsync(Contact item);
        Task UpdateContactItemAsync(Contact item, int id);
        Task DeleteContactItemAsync(int id);
    }
}
