namespace TaskApi.Dto.Task;

public class TaskCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }

    public TaskCreateDto(string title, string description)
    {   
        Title = title;
        Description = description;
    }
}