using ToDoApp.Core.Models;
using ToDoApp.DTOs.Request;
using ToDoApp.Repositories;

namespace ToDoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<IEnumerable<TaskInfo>> GetAllTasksAsync()
        {
            return await _todoRepository.GetAllAsync();
        }
        public async Task<TaskInfo?> GetTaskByIdAsync(int id)
        {
            return await _todoRepository.GetByIdAsync(id);
        }
        public async Task<TaskInfo> CreateTaskAsync(TaskRequest request)
        {
            var task = new TaskInfo
            {
                TaskName = request.TaskName,
                TaskDescription = request.TaskDescription,
                IsCompleted = request.IsCompleted,
                Recurrence = request.Recurrence,
                CreatedAt = DateTime.Now,
                DueDate = request.DueDate
            };
            return await _todoRepository.CreateAsync(task);
        }
        public async Task<bool> UpdateTaskAsync(int id, TaskRequest request)
        {
            var existingTask = await _todoRepository.GetByIdAsync(id);
            if (existingTask == null)
                return false;
            existingTask.TaskName = request.TaskName;
            existingTask.TaskDescription = request.TaskDescription;
            existingTask.IsCompleted = request.IsCompleted;
            existingTask.Recurrence = request.Recurrence;
            existingTask.DueDate = request.DueDate;
            return await _todoRepository.UpdateAsync(existingTask);
        }
        public async Task<bool> DeleteTaskAsync(int id)
        {
            var requestTask = await _todoRepository.GetByIdAsync(id);
            if (requestTask == null)
                return false;
            return await _todoRepository.DeleteAsync(id);
        }
    }
}
