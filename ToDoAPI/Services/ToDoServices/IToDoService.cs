namespace ToDoAPI.Services.ToDoServices
{
    public interface IToDoService
    {
        Task<List<ToDo>> GetAllTodos();
        Task<ToDo> GetSingleToDo(int id);
        Task<List<ToDo>> AddToDo(ToDo todo);
        Task<List<ToDo>> UpdateAll(int id, ToDo todo);
        Task<List<ToDo>> UpdateSomeToDo(int id, ToDo todo);
        Task<List<ToDo>> DeleteToDo(int id);
    }
}
