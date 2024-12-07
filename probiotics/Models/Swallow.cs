using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace probiotics.Models;

public class Swallow
{
    [Key]
    public int Id { get; set; } // 主键，自增

    [Required]
    [MaxLength(255)]
    public string Restaurant { get; set; } = string.Empty; // 餐厅名称，非空，最大长度 255

    [Required]
    [Column(TypeName = "decimal(3,1)")]
    public decimal Rating { get; set; } // 评分，1 位小数

    [MaxLength(200)]
    public string? Summary { get; set; } // 摘要，可为空，最大长度 500

    [Column(TypeName = "nvarchar(max)")]
    public string? Review { get; set; } // 长文本评论，可为空

    [MaxLength(500)]
    public string? CoverImage { get; set; } // 封面图片路径，可为空，最大长度 500

    [Required]
    public DateTime CreateTime { get; set; } = DateTime.Now; // 创建时间，默认当前时间

    public List<SwallowLink> Links { get; set; } = new List<SwallowLink>();

}