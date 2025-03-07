namespace TaskApi.Dto.User;

public class UserDto
{
    public Guid Id { get; init; }
    public string Email { get; set; }
    public string Role { get; set; }

    public UserDto(Entities.User entity)
    {
        Id = entity.Id;
        Email = entity.Email;
        Role = entity.Role;
    }
}