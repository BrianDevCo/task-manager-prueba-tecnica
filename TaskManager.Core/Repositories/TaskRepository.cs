using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Data;
using TaskManager.Core.Models;
using TaskManager.Core.Repositories;

namespace TaskManager.Core.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Task>> GetAllAsync()
    {
        return await _context.Tasks
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Task>> GetByStatusAsync(bool isCompleted)
    {
        return await _context.Tasks
            .Where(t => t.IsCompleted == isCompleted)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task<Task?> GetByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<Task> CreateAsync(Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<Task> UpdateAsync(Task task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
            return false;

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Tasks.AnyAsync(t => t.Id == id);
    }
}