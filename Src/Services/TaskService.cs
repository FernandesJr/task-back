using Microsoft.EntityFrameworkCore;
using Task.Dto;
using TaskApi.Data;
using TaskApi.Dto.Task;
using TaskApi.Repositories;

namespace TaskApi.Services;

public class TaskService
{
    private readonly TaskRepository _repository;

    public TaskService(TaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<TaskDto> CreateAsync(TaskCreateDto dto, CancellationToken ct)
    {
        if (dto == null) return null;
        var entity = await this._repository.CreateAsync(dto, ct);
        return new TaskDto(entity);
    }

    public List<TaskDto> AllTasks()
    {
        var tasks = _repository.AllTasks();
        return tasks.Select(t => new TaskDto(t)).ToList();
    }

    public async Task<TaskDto?> GetById(Guid id, CancellationToken ct)
    {
        var entity = await _repository.GetByIdAsync(id, ct);
        if (entity == null) return null;
        return new TaskDto(entity);
    }

    public async Task<TaskDto> Update(Guid id, TaskUpdate dto, CancellationToken ct)
    {
        var entity = await _repository.GetByIdAsync(id, ct);
        if (entity == null) return null;
        entity.Title = dto.Title;
        entity.Description = dto.Description;
        entity.FinishDateTime = dto.FinishDateTime;
        _repository.Update(entity);
        return new TaskDto(entity);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
    {
        var entity = await _repository.GetByIdAsync(id, ct);
        if (entity == null) return false;
        return await _repository.DeleteAsync(entity, ct);
    }
}