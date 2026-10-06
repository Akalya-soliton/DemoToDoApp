using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Models;
using ToDoApp.Core.Services;
using ToDoApp.DTOs.Request;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskInfo>>> GetAllTasks()
        {
            var tasks = await _todoService.GetAllTasksAsync();
            return Ok(tasks);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskInfo?>> GetTaskById(int id)
        {
            var task = await _todoService.GetTaskByIdAsync(id);
            if (task == null)
                return NotFound();
            return Ok(task);
        }
        [HttpPost]
        public async Task<ActionResult<TaskInfo>> CreateTask([FromBody] TaskRequest task)
        {
            var createdTask = await _todoService.CreateTaskAsync(new TaskInfo()
            {
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                IsCompleted = task.IsCompleted,
                Recurrence = task.Recurrence,
                CreatedAt = DateTime.Now,
                DueDate = task.DueDate
            });
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTask(int id)
        {
            var result = await _todoService.DeleteTaskAsync(id);
            if (!result)
                return NotFound();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateTask(int id, [FromBody] TaskRequest task)
        {
            var result = await _todoService.UpdateTaskAsync(id, new TaskInfo()
            {
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                IsCompleted = task.IsCompleted,
                Recurrence = task.Recurrence,
                DueDate = task.DueDate
            });
            if (!result)
                return NotFound();
            return Ok(result);
        }
    }
}
