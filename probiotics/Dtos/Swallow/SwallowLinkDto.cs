namespace probiotics.Dtos.Swallow;

public class SwallowLinkDto
{
    public int Id { get; set; }
    public string Link { get; set; } = string.Empty;
    public int? SwallowId { get; set; }
}