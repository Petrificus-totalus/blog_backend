namespace probiotics.Dtos.Swallow;

public class SwallowDetailDto
{
    public int Id { get; set; } 
    public string Restaurant { get; set; } = string.Empty; 
    public decimal Rating { get; set; } 
    public string? Review { get; set; }
    public List<string> Links { get; set; } = new List<string>();
}