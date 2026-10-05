using ToDoApp.Core.Models;
using ToDoApp.DTOs.Request;

namespace ToDoApp.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TaskInfo>> GetAllTasksAsync();
        Task<TaskInfo?> GetTaskByIdAsync(int id);
        Task<TaskInfo> CreateTaskAsync(TaskRequest task);
        Task<bool> UpdateTaskAsync(int id, TaskRequest task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
