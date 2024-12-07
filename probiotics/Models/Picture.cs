using System.ComponentModel.DataAnnotations;

namespace probiotics.Models;

public class Picture
{
    [Key]
    public int Id { get; set; } // 主键

    [Required]
    [MaxLength(500)]
    public string Link { get; set; } = string.Empty; // 图片链接

    [Required]
    public int SpendId { get; set; } // 外键

    public Spend Spend { get; set; } = null!; // 导航属性
}