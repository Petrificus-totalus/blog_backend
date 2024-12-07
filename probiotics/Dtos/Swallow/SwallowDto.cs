namespace probiotics.Dtos.Swallow;

public class SwallowDto
{

    public int Id { get; set; } 
    public string Restaurant { get; set; } = string.Empty; 
    public decimal Rating { get; set; } 
    public string? Summary { get; set; } 
    public string? CoverImage { get; set; } 
    public DateTime CreateTime { get; set; } = DateTime.Now; 
    
}