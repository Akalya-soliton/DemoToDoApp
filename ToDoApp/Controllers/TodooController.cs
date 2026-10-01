using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodooController : ControllerBase
    {
        private static List<TaskInfo> tasks = new List<TaskInfo>();

        // GET: api/<TodooController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TodooController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TodooController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TodooController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodooController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
