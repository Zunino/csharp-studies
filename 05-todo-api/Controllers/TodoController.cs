using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetStudies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetStudies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext context;

        public TodoController(TodoContext context)
        {
            this.context = context;

            if (context.TodoItems.Any()) return;
            
            context.TodoItems.Add(new TodoItem {Name = "Item 1"});
            context.SaveChanges();
        }

        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await context.TodoItems.ToListAsync();
        }

        // E.g. GET api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            context.TodoItems.Add(item);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoItem), new {id = item.Id}, item);
        }
    }
}