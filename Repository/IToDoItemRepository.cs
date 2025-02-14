using ToDoList.Model;

namespace ToDoList.Repository
{
    public interface IToDoItemRepository
    {
        Task AddAsync(ToDoItem toDoItem);                
        Task UpdateAsync(ToDoItem toDoItem);             
        Task DeleteAsync(int id);
        Task<ToDoItem> GetByIdAsync(int id);             
        Task<List<ToDoItem>> GetAllAsync();              
    }
}
