using Microsoft.EntityFrameworkCore;
using Mission10_harris.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Connect to the SQLite database
builder.Services.AddDbContext<BowlingContext>(options =>
    options.UseSqlite("Data Source=Data/BowlingLeague.sqlite"));

// Enable CORS so the React frontend can call this API
builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Allow requests from any origin (needed for React on a different port)
app.UseCors(x => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

// GET endpoint that returns bowlers on the Marlins and Sharks teams
app.MapGet("/bowlers", (BowlingContext context) =>
{
    return context.Bowlers
        .Include(b => b.Team) // join with Teams table
        .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
        .Select(b => new
        {
            // Handle nulls in name fields
            Name = (b.BowlerFirstName ?? "") + " " + (b.BowlerMiddleInit ?? "") + " " + (b.BowlerLastName ?? ""),
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