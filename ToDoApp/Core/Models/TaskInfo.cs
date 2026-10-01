using ToDoApp.TodoApp.Core.Enums;

namespace ToDoApp.TodoApp.Core.Models
{
    public class TaskInfo
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string? TaskDescription { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public RecurrenceType Recurrence { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
