using System.ComponentModel.DataAnnotations;
using ToDoApp.Core.Enums;

namespace ToDoApp.DTOs.Request
{
    public class TaskRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Task name must be between 1 and 50 characters.")]
        public string TaskName { get; set; } = string.Empty;
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Task description must be between 1 and 100 characters.")]
        public string? TaskDescription { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        [EnumDataType(typeof(RecurrenceType), ErrorMessage = "Invalid recurrence type.")]
        public RecurrenceType Recurrence { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
