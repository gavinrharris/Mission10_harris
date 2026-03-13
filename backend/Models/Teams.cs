namespace Mission10_harris.Models;

public class Team
{
    public int TeamId { get; set; }
    public string TeamName { get; set; }
    public int CaptainId { get; set; }
    
    public List<Bowler> Bowlers { get; set; }
}