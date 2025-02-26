namespace TaskApi.Dto.Task;

public class TaskDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? FinishDateTime { get; set; }

    public TaskDto(Entities.Task entity)
    {
        Id = entity.Id;
        Title = entity.Title;
        Description = entity.Description;
        FinishDateTime = entity.FinishDateTime;
    }
}