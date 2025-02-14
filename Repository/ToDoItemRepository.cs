using ToDoList.Model;
using ToDoList.AppDb;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ToDoList.Repository
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly AppDbContext _context;

        public ToDoItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task AddAsync(ToDoItem toDoItem)
        {
            await _context.ToDoItems.AddAsync(toDoItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ToDoItem toDoItem)
        {
            _context.ToDoItems.Update(toDoItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);
            if (toDoItem != null)
            {
                _context.ToDoItems.Remove(toDoItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
