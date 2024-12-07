namespace probiotics.Dtos.Algorithm;

public class CreateAlgorithmDto
{
    public List<int> Labels { get; set; }
    public string Desc { get; set; } = string.Empty;
    
    public string Content { get; set; } = string.Empty;
}