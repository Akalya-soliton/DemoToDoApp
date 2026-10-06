using ToDoApp.Core.Models;
namespace ToDoApp.Core.Repositories

{
    public interface ITodoRepository
    {
        Task<IEnumerable<TaskInfo>> GetAllAsync();
        Task<TaskInfo?> GetByIdAsync(int id);
        Task<TaskInfo> CreateAsync(TaskInfo task);
        Task<bool> UpdateAsync(TaskInfo task);
        Task<bool> DeleteAsync(int id);
    }
}
