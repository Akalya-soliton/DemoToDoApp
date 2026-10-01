using Microsoft.AspNetCore.Mvc;
using ToDoApp.Enums;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private static int nextId;
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
        public ActionResult<TaskInfo> Post([FromBody] TaskInfo task)
        {
            task.Id = nextId++;
            tasks.Add(task);
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
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
        public ActionResult Update(int id, [FromBody] TaskInfo updatedTask)
        {
            var task = tasks.FirstOrDefault(task => task.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            task.DueDate = updatedTask.DueDate;
            task.Recurrence = updatedTask.Recurrence;
            task.TaskName = updatedTask.TaskName;
            task.CreatedAt = updatedTask.CreatedAt;
            task.TaskDescription = updatedTask.TaskDescription;
            task.IsCompleted = updatedTask.IsCompleted;
            return NoContent();
        }
    }
}
