using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace probiotics.Models;

public class Spend
{
    [Key]
    public int Id { get; set; } // 主键

    [Required]
    public DateTime CreateTime { get; set; } = DateTime.Now; // 默认当前时间

    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty; // 标题

    [MaxLength(255)]
    public string Location { get; set; } = string.Empty; // 位置

    [Required]
    [Column(TypeName = "decimal(10,1)")]
    public decimal Price { get; set; } // 价格，保留 1 位小数

    public string? Description { get; set; } // 长文本描述

    public List<Picture> Pictures { get; set; } = new(); // 一对多关系

    public List<SpendTag> SpendTags { get; set; } = new(); 
}