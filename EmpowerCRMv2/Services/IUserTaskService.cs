using EmpowerCRMv2.Models;

namespace EmpowerCRMv2.Services
{
    public interface IUserTaskService
    {
        Task<List<UserTask>> GetAllUserTaskItemsAsync();
        Task AddUserTaskItemAsync(UserTask item);
        Task UpdateUserTaskItemAsync(UserTask item);
        Task DeleteUserTaskItemAsync(int id);
        Task<List<UserTaskPriority>> GetUserTaskPrioritiesAsync();
        Task<List<UserTaskStatus>> GetUserTaskStatusesAsync();
    }
}
