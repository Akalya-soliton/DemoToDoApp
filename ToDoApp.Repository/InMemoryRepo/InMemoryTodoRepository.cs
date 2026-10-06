using ToDoApp.Core.Enums;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Repositories
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        private readonly List<TaskInfo> _tasks;
        private int _nextId;
        private readonly object _lock = new ();
        public InMemoryTodoRepository()
        {
            _tasks = new List<TaskInfo>
            {
                new TaskInfo { Id = _nextId++, TaskName = "Task 1", CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddDays(1), IsCompleted = false, Recurrence = RecurrenceType.None, TaskDescription = "Description for Task 1" },
                new TaskInfo { Id = _nextId++, TaskName = "Task 2", CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddDays(2), IsCompleted = true, Recurrence = RecurrenceType.Daily, TaskDescription = "Description for Task 2" },
                new TaskInfo { Id = _nextId++, TaskName = "Task 3", CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddDays(3), IsCompleted = true, Recurrence = RecurrenceType.Monthly, TaskDescription = "Description for Task 3" }
            };
        }
        public Task<IEnumerable<TaskInfo>> GetAllAsync()
        {
            lock (_lock)
            {
                return Task.FromResult<IEnumerable<TaskInfo>>(_tasks.ToList());
            }
        }

        public Task<TaskInfo?> GetByIdAsync(int id)
        {
            lock (_lock)
            {
                var task = _tasks.FirstOrDefault(t => t.Id == id);
                return Task.FromResult(task);
            }
        }

        public Task<TaskInfo> CreateAsync(TaskInfo task)
        {
            lock (_lock)
            {
                task.Id = _nextId++;
                _tasks.Add(task);
                return Task.FromResult(task);
            }
        }

        public Task<bool> UpdateAsync(TaskInfo task)
        {
            lock (_lock)
            {
                var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
                if (existingTask == null)
                    return Task.FromResult(false);

                _tasks.Remove(existingTask);
                _tasks.Add(task);
                return Task.FromResult(true);
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            lock (_lock)
            {
                var task = _tasks.FirstOrDefault(t => t.Id == id);
                if (task == null)
                    return Task.FromResult(false);

                _tasks.Remove(task);
                return Task.FromResult(true);
            }
        }
    }
}
