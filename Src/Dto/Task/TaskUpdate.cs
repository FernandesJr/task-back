using TaskApi.Dto.Task;

namespace Task.Dto;

public class TaskUpdate : TaskCreateDto
{
    public DateTime? FinishDateTime { get; set; }

    public TaskUpdate(string title, string description) : base(title, description) {}
}