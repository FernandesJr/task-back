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
    
}