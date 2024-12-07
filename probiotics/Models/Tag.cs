using System.ComponentModel.DataAnnotations;

namespace probiotics.Models;

public class Tag
{
    [Key]
    public int Id { get; set; } // 主键

    [Required]
    [MaxLength(100)]
    public string TagName { get; set; } = string.Empty; // 标签名称

    public List<SpendTag> SpendTags { get; set; } = new();
}