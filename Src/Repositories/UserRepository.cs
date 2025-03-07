using TaskApi.Data;
using TaskApi.Entities;

namespace TaskApi.Repositories;

public class UserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> createdAsync(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
    
    public User GetByEmail(String email)
    {
        var entity = _context.Users.FirstOrDefault(u => u.Email == email);
        return entity;
    }
}