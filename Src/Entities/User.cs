using System.ComponentModel.DataAnnotations;

namespace TaskApi.Entities;

public class User
{
    public Guid Id { get; init; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    
    public string Role { get; set; }

    public User(string email, string password)
    {
        Id = Guid.NewGuid();
        Email = email;
        Password = password;
        Role = "Admin";
    }
}