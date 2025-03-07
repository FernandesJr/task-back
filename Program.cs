using TaskApi.Data;
using TaskApi.Repositories;
using TaskApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<TaskService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Permite o frontend Angular
                .AllowAnyMethod() // Permite todos os métodos (GET, POST, PUT, DELETE)
                .AllowAnyHeader(); // Permite qualquer cabeçalho
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors("AllowSpecificOrigin");

app.Run();
