using ToDoApp.TodoApp.Core.Enums;

namespace ToDoApp.ToDoApp.DTOs.Request
{
    public class TaskRequest
    {
        public string TaskName { get; set; } = string.Empty;
        public string? TaskDescription { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public RecurrenceType Recurrence { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
