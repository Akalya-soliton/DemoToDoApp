using ToDoApp.Core.Models;

namespace ToDoApp.Core.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TaskInfo>> GetAllTasksAsync();
        Task<TaskInfo?> GetTaskByIdAsync(int id);
        Task<TaskInfo> CreateTaskAsync(TaskInfo task);
        Task<bool> UpdateTaskAsync(int id, TaskInfo task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
