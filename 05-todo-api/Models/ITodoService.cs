using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetStudies.Models
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetTodoItems();
        Task<IEnumerable<TodoItem>> GetPendingTodoItems();
        Task<TodoItem> GetTodoItem(long id);
        Task AddTodoItem(TodoItem todoItem);
        Task RemoveTodoItem(long id);
    }
}
