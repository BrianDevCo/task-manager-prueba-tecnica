using System.Net.Http.Json;
using TaskManager.Core.DTOs;

namespace TaskManager.Blazor.Services;

public class TaskService : ITaskService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<TaskService> _logger;

    public TaskService(HttpClient httpClient, ILogger<TaskService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<TaskDto>>("api/tasks");
            return response ?? Enumerable.Empty<TaskDto>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener tareas");
            return Enumerable.Empty<TaskDto>();
        }
    }

    public async Task<IEnumerable<TaskDto>> GetTasksByStatusAsync(bool isCompleted)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<TaskDto>>($"api/tasks?isCompleted={isCompleted}");
            return response ?? Enumerable.Empty<TaskDto>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener tareas por estado");
            return Enumerable.Empty<TaskDto>();
        }
    }

    public async Task<TaskDto?> GetTaskByIdAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<TaskDto>($"api/tasks/{id}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener tarea {TaskId}", id);
            return null;
        }
    }

    public async Task<TaskDto> CreateTaskAsync(CreateTaskDto createTaskDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/tasks", createTaskDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TaskDto>() ?? throw new Exception("Error al crear tarea");
    }

    public async Task<TaskDto?> UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/tasks/{id}", updateTaskDto);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<TaskDto>();
        }
        return null;
    }

    public async Task<TaskDto?> CompleteTaskAsync(int id)
    {
        var response = await _httpClient.PutAsync($"api/tasks/{id}/complete", null);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<TaskDto>();
        }
        return null;
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/tasks/{id}");
        return response.IsSuccessStatusCode;
    }
}