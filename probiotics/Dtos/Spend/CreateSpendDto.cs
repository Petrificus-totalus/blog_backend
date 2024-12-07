using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using probiotics.Models;

namespace probiotics.Dtos.Spend;

public class CreateSpendDto
{
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

    // Tags 用于传递标签 ID 列表
    public List<int> Tags { get; set; } = new();

    // Pictures 用于传递图片链接列表
    public List<string> PictureLinks { get; set; } = new();
}