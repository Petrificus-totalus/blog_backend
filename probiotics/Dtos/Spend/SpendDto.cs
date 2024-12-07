using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using probiotics.Dtos.Picture;
using probiotics.Dtos.Tag;
using probiotics.Models;

namespace probiotics.Dtos.Spend;

public class SpendDto
{
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

    public List<TagDto> Tags { get; set; } = new();
    public bool HasDetail;
}