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
        private string? _userId;
        private string? _userRole;
        public ContactService(ApplicationDbContext context = null, IHttpContextAccessor httpContextAccessor = null)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            var claimsPrincipal = _httpContextAccessor.HttpContext.User;
            _userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _userRole = claimsPrincipal.FindFirst(ClaimTypes.Role)?.Value;
        }

        public async Task AddContactItemAsync(Contact item)
        {
            item.OwnerId = _userId;
            _context.Contacts.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactItemAsync(int id)
        {
            Contact? contactItem;
            if (_userRole == "Administrator")
            {
                contactItem = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            }
            else
            {
                contactItem = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id && c.Owner.Id == _userId);
            }
            if (contactItem != null)
            {
                _context.Contacts.Remove(contactItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Contact>> GetAllContactItemsAsync()
        {
            if (_userRole == "Administrator")
            {
                return await _context.Contacts.Include(c => c.Owner).ToListAsync();
            }
            return await _context.Contacts.Where(c => c.Owner.Id == _userId).Include(c => c.Owner).ToListAsync();
        }

        public async Task<Contact?> GetContactItemByIdAsync(int id)
        {
            if(_userRole == "Administrator")
            {
                return await _context.Contacts.Include(c => c.Opportunities).ThenInclude(o => o.Stage).FirstOrDefaultAsync(c => c.Id == id);
            }
            return await _context.Contacts.Include(c => c.Opportunities).ThenInclude(o => o.Stage).FirstOrDefaultAsync(c => c.Id == id && c.Owner.Id == _userId);
        }

        public async Task UpdateContactItemAsync(Contact item, int id)
        {
            Contact? dbItem;
            if (_userRole == "Administrator")
            {
                await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            }
            dbItem = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id && c.Owner.Id == _userId);
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
