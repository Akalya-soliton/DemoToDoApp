using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;
using ToDoApp.DataBaseRepo.Data;

namespace ToDoApp.DataBaseRepo
{
    public class EfTodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public EfTodoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TaskInfo>> GetAllAsync()
        {
            return await _context.Tasks.AsNoTracking().OrderBy(t => t.Id).ToListAsync();
        }


        public async Task<TaskInfo?> GetByIdAsync(int id)
            => await _context.Tasks.FindAsync(id);

        public async Task<TaskInfo> CreateAsync(TaskInfo task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> UpdateAsync(TaskInfo task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
         if (task == null)
            {
                return false;
            }
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}