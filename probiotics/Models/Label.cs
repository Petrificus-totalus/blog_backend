namespace probiotics.Models;

public class Label
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<AlgoLabel> AlgoLabels { get; set; } = new List<AlgoLabel>();
}