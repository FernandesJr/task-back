using Microsoft.AspNetCore.Mvc;
using Task.Dto;
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
    public ActionResult<List<TaskDto>> AllTasks()
    {
        var tasks = _service.AllTasks();
        if (!tasks.Any()) NoContent();
        return Ok(tasks);
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

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<TaskDto>> Update(Guid id, TaskUpdate dto, CancellationToken ct)
    {
        TaskDto newDto = await _service.Update(id, dto, ct);
        if (newDto == null) return NotFound("Task not found, please verify");
        return Ok(newDto);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken ct)
    {
        var deleted = await _service.DeleteAsync(id, ct);
        if (!deleted) return NotFound("Task not found, please verify");
        return NoContent();
    }
    
}