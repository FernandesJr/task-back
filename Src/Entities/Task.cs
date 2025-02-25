using System.ComponentModel.DataAnnotations;
using TaskApi.Dto.Task;

namespace TaskApi.Entities;

public class Task
{
    public Guid Id { get; init; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime FinishDateTime { get; set; }

    public Task(string title, string description)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
    }

    public Task (TaskDto dto)
    {
        Title = dto.Title;
        Description = dto.Description;
    }
}