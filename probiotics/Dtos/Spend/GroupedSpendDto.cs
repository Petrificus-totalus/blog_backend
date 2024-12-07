namespace probiotics.Dtos.Spend;

public class GroupedSpendDto
{
    public DateTime CreateTime { get; set; } // 按日期分组的时间
    public decimal Total { get; set; } // 同一天的总价格
    public List<SpendDto> Items { get; set; } = new(); 
}