using EmpowerCRMv2.Data;
using EmpowerCRMv2.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EmpowerCRMv2.Services
{
    public class UserTaskService : IUserTaskService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string? _userId;
        private string? _userRole;

        public UserTaskService(ApplicationDbContext context = null, IHttpContextAccessor httpContextAccessor = null)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            var claimsPrincipal = _httpContextAccessor.HttpContext.User;
            _userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _userRole = claimsPrincipal.FindFirst(ClaimTypes.Role)?.Value;
        }
        public async Task AddUserTaskItemAsync(UserTask item)
        {
            item.CreatedDate = DateTime.UtcNow;
            item.LastModifiedDate = DateTime.UtcNow;
            _context.UserTasks.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserTaskItemAsync(int id)
        {
            UserTask? userTaskItem;
            if (_userRole == "Administrator")
            {
                userTaskItem = await _context.UserTasks.FirstOrDefaultAsync(ut => ut.Id == id);
            }
            else
            {
                userTaskItem = await _context.UserTasks.FirstOrDefaultAsync(ut => ut.Id == id && ut.Opportunity.Contact.Owner!.Id == _userId);
            }
            if (userTaskItem != null)
            {
                _context.UserTasks.Remove(userTaskItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<UserTask>> GetAllUserTaskItemsAsync()
        {
            if (_userRole == "Administrator")
            {
                return await _context.UserTasks.Include(ut => ut.Status)
                                                .Include(ut => ut.Priority)
                                                .Include(ut => ut.Opportunity)
                                                .ThenInclude(o => o.Contact)
                                                .ThenInclude(c => c.Owner)
                                                .OrderByDescending(ut => ut.DueDate).ToListAsync();
            }
            return await _context.UserTasks.Where(ut => ut.Opportunity.Contact.Owner!.Id == _userId)
                                                .Include(ut => ut.Status)
                                                .Include(ut => ut.Priority)
                                                .Include(ut => ut.Opportunity)
                                                .ThenInclude(o => o.Contact)
                                                .ThenInclude(c => c.Owner)
                                                .OrderByDescending(ut => ut.DueDate).ToListAsync();
        }

        public async Task UpdateUserTaskItemAsync(UserTask item)
        {
            UserTask? dbItem;
            if (_userRole == "Administrator")
            {
                dbItem = await _context.UserTasks.FirstOrDefaultAsync(ut => ut.Id == item.Id);
            }
            else
            {
                dbItem = await _context.UserTasks.FirstOrDefaultAsync(ut => ut.Id == item.Id && ut.Opportunity.Contact.Owner!.Id == _userId);
            }
            if (dbItem != null)
            {
                dbItem.Name = item.Name;
                dbItem.Subject = item.Subject;
                dbItem.Description = item.Description;
                dbItem.DueDate = item.DueDate;
                dbItem.StatusId = item.StatusId;
                dbItem.PriorityId = item.PriorityId;
                dbItem.OpportunityId = item.OpportunityId;
                dbItem.LastModifiedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<UserTaskPriority>> GetUserTaskPrioritiesAsync()
        {
            return await _context.UserTaskPriorities.ToListAsync();
        }

        public async Task<List<UserTaskStatus>> GetUserTaskStatusesAsync()
        {
            return await _context.UserTaskStatuses.ToListAsync();
        }
    }
}
