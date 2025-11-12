using Microsoft.AspNetCore.Mvc;
using TaskManager.Core.DTOs;
using TaskManager.Core.Services;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly ILogger<TasksController> _logger;

    public TasksController(ITaskService taskService, ILogger<TasksController> logger)
    {
        _taskService = taskService;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene todas las tareas
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TaskDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks([FromQuery] bool? isCompleted = null)
    {
        try
        {
            IEnumerable<TaskDto> tasks;

            if (isCompleted.HasValue)
            {
                tasks = await _taskService.GetTasksByStatusAsync(isCompleted.Value);
            }
            else
            {
                tasks = await _taskService.GetAllTasksAsync();
            }

            return Ok(tasks);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener tareas");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Obtiene una tarea por ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TaskDto>> GetTask(int id)
    {
        try
        {
            var task = await _taskService.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound(new { message = $"Tarea con ID {id} no encontrada" });
            }

            return Ok(task);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener tarea {TaskId}", id);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Crea una nueva tarea
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(TaskDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TaskDto>> CreateTask([FromBody] CreateTaskDto createTaskDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await _taskService.CreateTaskAsync(createTaskDto);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear tarea");
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Actualiza una tarea existente
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TaskDto>> UpdateTask(int id, [FromBody] UpdateTaskDto updateTaskDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = await _taskService.UpdateTaskAsync(id, updateTaskDto);

            if (task == null)
            {
                return NotFound(new { message = $"Tarea con ID {id} no encontrada" });
            }

            return Ok(task);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar tarea {TaskId}", id);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Marca una tarea como completada
    /// </summary>
    [HttpPut("{id}/complete")]
    [ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TaskDto>> CompleteTask(int id)
    {
        try
        {
            var task = await _taskService.CompleteTaskAsync(id);

            if (task == null)
            {
                return NotFound(new { message = $"Tarea con ID {id} no encontrada" });
            }

            return Ok(task);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al completar tarea {TaskId}", id);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }

    /// <summary>
    /// Elimina una tarea
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTask(int id)
    {
        try
        {
            var deleted = await _taskService.DeleteTaskAsync(id);

            if (!deleted)
            {
                return NotFound(new { message = $"Tarea con ID {id} no encontrada" });
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al eliminar tarea {TaskId}", id);
            return StatusCode(500, new { message = "Error interno del servidor" });
        }
    }
}