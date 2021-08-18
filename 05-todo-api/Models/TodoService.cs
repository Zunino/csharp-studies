using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DotnetStudies.Models
{
    public class TodoService : ITodoService
    {
        private readonly TodoContext todoContext;

        public TodoService(TodoContext todoContext)
        {
            this.todoContext = todoContext;

            if (!todoContext.TodoItems.Any())
            {
                todoContext.TodoItems.Add(new TodoItem {Name = "Study C++", IsComplete = true});
                todoContext.TodoItems.Add(new TodoItem {Name = "Study Dotnet Core"});
                todoContext.TodoItems.Add(new TodoItem {Name = "Play games"});
                todoContext.SaveChanges();
            }
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItems() =>
            await todoContext.TodoItems.ToListAsync();

        public async Task<IEnumerable<TodoItem>> GetPendingTodoItems() =>
            await todoContext.TodoItems.Where(i => i.IsComplete == false).ToListAsync();

        public async Task<TodoItem> GetTodoItem(long id) =>
            await todoContext.TodoItems.FindAsync(id);

        public async Task AddTodoItem(TodoItem todoItem)
        {
            await todoContext.AddAsync(todoItem);
            await todoContext.SaveChangesAsync();
        }

        public async Task RemoveTodoItem(long id)
        {
            var item = await todoContext.TodoItems.FindAsync(id);
            if (item == null)
            {
                return;
            }
            todoContext.Remove(item);
            await todoContext.SaveChangesAsync();
        }
    }
}
