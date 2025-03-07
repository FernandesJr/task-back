using Microsoft.EntityFrameworkCore;

namespace TaskApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<Entities.Task> Tasks { get; set; }
    public DbSet<Entities.User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}