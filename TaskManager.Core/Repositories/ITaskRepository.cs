using TaskManager.Core.Models;

namespace TaskManager.Core.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<Task>> GetAllAsync();
    Task<IEnumerable<Task>> GetByStatusAsync(bool isCompleted);
    Task<Task?> GetByIdAsync(int id);
    Task<Task> CreateAsync(Task task);
    Task<Task> UpdateAsync(Task task);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}