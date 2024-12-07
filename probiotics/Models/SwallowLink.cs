namespace probiotics.Models;

public class SwallowLink
{
    public int Id { get; set; }
    public string Link { get; set; } = string.Empty;
    public int? SwallowId { get; set; }
    // Navigation Property
    public Swallow? Swallow { get; set; }
}