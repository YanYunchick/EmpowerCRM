using EmpowerCRMv2.Data;
using EmpowerCRMv2.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EmpowerCRMv2.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ContactService(ApplicationDbContext context = null, IHttpContextAccessor httpContextAccessor = null)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddContactItemAsync(Contact item)
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext.User;
            var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            item.OwnerId = userId;
            _context.Contacts.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactItemAsync(int id)
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext.User;
            var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var contactItem = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id && c.Owner.Id == userId);
            if (contactItem != null)
            {
                _context.Contacts.Remove(contactItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Contact>> GetAllItemsAsync()
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext.User;
            var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return await _context.Contacts.Where(c => c.Owner.Id == userId).Include(c => c.Owner).ToListAsync();
        }

        public async Task<Contact> GetContactItemByIdAsync(int id)
        {
            var claimsPrincipal = _httpContextAccessor?.HttpContext?.User;
            var userId = claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var contactItem = await _context.Contacts.Include(c => c.Opportunities).ThenInclude(o => o.Stage).FirstOrDefaultAsync(c => c.Id == id && c.Owner.Id == userId);
            return contactItem;
        }

        public async Task UpdateContactItemAsync(Contact item, int id)
        {
            var claimsPrincipal = _httpContextAccessor?.HttpContext?.User;
            var userId = claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var dbItem = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id && c.Owner.Id == userId);
            if (dbItem != null)
            {
                dbItem.FirstName = item.FirstName;
                dbItem.LastName = item.LastName;
                dbItem.Email = item.Email;
                dbItem.Phone = item.Phone;
                dbItem.Address = item.Address;
                dbItem.Company = item.Company;

                await _context.SaveChangesAsync();
            }
        }
    }
}
