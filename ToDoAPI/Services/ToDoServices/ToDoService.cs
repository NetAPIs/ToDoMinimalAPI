using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ToDoAPI.Services.ToDoServices
{
    public class ToDoService : IToDoService
    {
        private readonly DataContext _context;
        public ToDoService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<ToDo>> AddToDo(ToDo todo)
        {
            _context.ToDos.Add(todo);
            await _context.SaveChangesAsync();
            return await _context.ToDos.ToListAsync();
        }

        public async Task<List<ToDo>> DeleteToDo(int id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            if (todo == null)
                return null;

            _context.ToDos.Remove(todo);
            await _context.SaveChangesAsync();
            return await _context.ToDos.ToListAsync();
        }

        public async Task<List<ToDo>> GetAllTodos()
        {
            var todos = await _context.ToDos.ToListAsync();
            return todos;
        }

        public async Task<ToDo> GetSingleToDo(int id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            if (todo == null)
                return null;
            return todo;
        }

        public async Task<List<ToDo>> UpdateAll(int id, ToDo newToDo)
        {
            var todo = await _context.ToDos.FindAsync(id);
            if (todo == null)
                return null;

            todo.Name = newToDo.Name;
            todo.Description = newToDo.Description;
            todo.AddedIn = newToDo.AddedIn;

            await _context.SaveChangesAsync();

            return await _context.ToDos.ToListAsync();
        }

        public async Task<List<ToDo>> UpdateSomeToDo(int id, ToDo update)
        {
            var todo = await _context.ToDos.FindAsync(id);
            if (todo == null)
                return null;

            todo.Name = update.Name ?? todo.Name;
            todo.Description = update.Description ?? todo.Description;

            await _context.SaveChangesAsync();

            return await _context.ToDos.ToListAsync();
        }
    }
}
