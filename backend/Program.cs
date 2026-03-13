using Microsoft.EntityFrameworkCore;
using Mission10_harris.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<BowlingContext>(options =>
    options.UseSqlite("Data Source=Data/BowlingLeague.sqlite"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/bowlers", (BowlingContext context) =>
{
    return context.Bowlers
        .Include(b => b.Team)
        .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
        .Select(b => new
        {
            Name = b.BowlerFirstName + " " + b.BowlerMiddleInit + " " + b.BowlerLastName,
            Team = b.Team.TeamName,
            b.BowlerAddress,
            b.BowlerCity,
            b.BowlerState,
            b.BowlerZip,
            b.BowlerPhoneNumber
        })
        .ToList();
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}