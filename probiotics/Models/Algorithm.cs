using System.ComponentModel.DataAnnotations.Schema;

namespace probiotics.Models;

public class Algorithm
{
    public int Id { get; set; }
    [Column(TypeName = "varchar(255)")]
    public string Desc { get; set; } = string.Empty;
    [Column(TypeName = "varchar(max)")]
    public string Content { get; set; } = string.Empty;
    public List<AlgoLabel> AlgoLabels { get; set; } = new List<AlgoLabel>();
}