using Microsoft.AspNetCore.Mvc;
using TaskApi.Dto.Task;
using TaskApi.Services;

namespace TaskApi.Controllers;

[Route("api/tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly TaskService _service;
    
    public TaskController(TaskService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public List<TaskDto> AllTasks()
    {
        var tasks = _service.AllTasks();
        return tasks;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TaskDto>> GetById(Guid id, CancellationToken ct)
    {
        var task = await _service.GetById(id, ct);
    
        if (task == null) return NotFound("Task not found, please verify");
    
        return Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> Create(TaskCreateDto dto, CancellationToken ct)
    {
        TaskDto newDto = await _service.CreateAsync(dto, ct);
        if (newDto == null) return BadRequest("Fields required, please verify");
        return CreatedAtAction(nameof(GetById), new { id = newDto.Id }, newDto);
    }
    
}