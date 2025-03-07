using TaskApi.Data;
using TaskApi.Dto.Task;

namespace TaskApi.Repositories;

public class TaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Entities.Task> CreateAsync(TaskCreateDto dto, CancellationToken ct)
    {
        var entity = new Entities.Task(dto.Title, dto.Description);
        await _context.Tasks.AddAsync(entity, ct);
        await _context.SaveChangesAsync(ct);
        return entity;
    }
    
    public List<Entities.Task>AllTasks()
    {
        return _context.Tasks
            .ToList();
    }
    
    public async Task<Entities.Task?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var entity = await _context.Tasks.FindAsync(id, ct);
        return entity;
    }
    
    public void Update(Entities.Task enetity)
    {
        _context.Tasks.Update(enetity);
        _context.SaveChanges();
    }
    
    public async Task<bool> DeleteAsync(Entities.Task entity, CancellationToken ct)
    {
        _context.Tasks.Remove(entity);
        await _context.SaveChangesAsync(ct);
        return true;
    }
}