namespace probiotics.Models;

public class SpendTag
{
    public int SpendId { get; set; } // 外键，关联 Transaction
    public Spend Spend { get; set; } = null!; // 导航属性

    public int TagId { get; set; } // 外键，关联 Tag
    public Tag Tag { get; set; } = null!; // 导航属性
}