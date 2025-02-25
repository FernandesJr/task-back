using Microsoft.EntityFrameworkCore;
using Task.Dto;
using TaskApi.Data;
using TaskApi.Dto.Task;

namespace TaskApi.Services;

public class TaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TaskDto> CreateAsync (TaskCreateDto dto, CancellationToken ct)
    {
        var entity = new Entities.Task(dto.Title, dto.Description);
        await _context.Tasks.AddAsync(entity, ct);
        await _context.SaveChangesAsync(ct);
        return new TaskDto(entity);
    }

    public List<TaskDto> AllTasks ()
    {
        return _context.Tasks
            .Select(task => new TaskDto(task))
            .ToList();
    }

    public async Task<TaskDto> UpdateAsync (Guid id, TaskUpdate dto, CancellationToken ct)
    {
        Entities.Task entity = await _context.Tasks.SingleOrDefaultAsync(task => task.Id == id, ct);
        if (entity == null) return null;
        entity.Title = dto.Title;
        entity.Description = dto.Description;
        await _context.SaveChangesAsync(ct);
        return new TaskDto(entity);
    }

    public async Task<bool> DeleteAsync (Guid id, CancellationToken ct)
    {
        var entity = await _context.Tasks.FindAsync(id, ct);
        if (entity == null) return false;
        _context.Tasks.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}