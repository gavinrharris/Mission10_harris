using Microsoft.EntityFrameworkCore;
using Mission10_harris.Models;

namespace Mission10_harris.Data;

public class BowlingContext : DbContext
{
    public BowlingContext(DbContextOptions<BowlingContext> options) : base(options) {}
    public DbSet<Bowler> Bowlers { get; set; }
    public DbSet<Team> Teams  { get; set; }
}