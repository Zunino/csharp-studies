using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetStudies.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetStudies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService todoService;

        public TodoController(TodoContext context, ITodoService todoService)
        {
            this.todoService = todoService;
        }

        // GET api/todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return Ok(await todoService.GetTodoItems());
        }

        // GET api/todo/pending
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetPendingTodoItems()
        {
            return Ok(await todoService.GetPendingTodoItems());
        }

        // GET api/todo/<n>
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await todoService.GetTodoItem(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            await todoService.AddTodoItem(item);
            return CreatedAtAction(nameof(GetTodoItem), new {id = item.Id}, item);
        }

        /* [HttpPut("{id}")] */
        /* public async Task<IActionResult> PutTodoItem(long id, TodoItem item) */
        /* { */
        /*     if (id != item.Id) */
        /*     { */
        /*         return BadRequest(); */
        /*     } */

        /*     context.Entry(item).State = EntityState.Modified; */
        /*     await context.SaveChangesAsync(); */

        /*     return NoContent(); */
        /* } */

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            await todoService.RemoveTodoItem(id);
            return NoContent();
        }
    }
}
