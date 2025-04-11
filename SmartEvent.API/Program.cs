using _1.SmartEvent.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

using _1.SmartEvent.Data.DbContexte;
using _1.SmartEvent.Data.Repositories;
using _1.SmartEvent.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAdminFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Replace with your frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSmartFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5174") // Replace with your frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


// Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SmartEventDBContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Register Repositories
builder.Services.AddScoped<IEventRepository, EventRepository>();
// Add other repositories here

// Register Services
builder.Services.AddScoped<IEventService, EventService>();
// Add other services here

var app = builder.Build();
app.UseCors("AllowAdminFrontend");
app.UseCors("AllowSmartFrontend");

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection(); // ← Redirects HTTP to HTTPS (ensure you test HTTPS)
app.UseRouting();
//app.UseAuthorization();
app.MapControllers();

app.UseDefaultFiles();
app.UseStaticFiles();



app.Run();