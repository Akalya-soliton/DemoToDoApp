using Microsoft.AspNetCore.Mvc;
using ToDoApp.TodoApp.Core.Enums;
using ToDoApp.TodoApp.Core.Models;
using ToDoApp.ToDoApp.DTOs.Request;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private static int nextId = 1;
        private static List<TaskInfo> tasks = new()
        {  new TaskInfo { Id = nextId++, TaskName = "Task 1", CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddDays(1), IsCompleted = false, Recurrence = RecurrenceType.None, TaskDescription = "Description for Task 1" },
           new TaskInfo { Id = nextId++, TaskName = "Task 2", CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddDays(2), IsCompleted = true, Recurrence = RecurrenceType.None, TaskDescription = "Description for Task 2" },
           new TaskInfo { Id = nextId++, TaskName = "Task 3", CreatedAt = DateTime.Now, DueDate = DateTime.Now.AddDays(3), IsCompleted = true, Recurrence = RecurrenceType.None, TaskDescription = "Description for Task 3" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<TaskInfo>> GetAll()
        {
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<TaskInfo> Get(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<TaskInfo> Post([FromBody] TaskRequest task)
        {
            var taskInfo = new TaskInfo
            {
                Id = nextId++,
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                IsCompleted = task.IsCompleted,
                Recurrence = task.Recurrence,
                DueDate = task.DueDate,
                CreatedAt = DateTime.Now
            };
            tasks.Add(taskInfo);
            return CreatedAtAction(nameof(Get), new { id = taskInfo.Id }, taskInfo);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            tasks.Remove(task);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] TaskRequest updatedTask)
        {
            var task = tasks.FirstOrDefault(task => task.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            task.DueDate = updatedTask.DueDate;
            task.Recurrence = updatedTask.Recurrence;
            task.TaskName = updatedTask.TaskName;
            task.TaskDescription = updatedTask.TaskDescription;
            task.IsCompleted = updatedTask.IsCompleted;
            return NoContent();
        }
    }
}
