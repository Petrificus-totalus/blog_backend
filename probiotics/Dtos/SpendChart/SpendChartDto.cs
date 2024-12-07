namespace probiotics.Dtos.SpendChart;

public class SpendChartDto
{
    public string CreateTime { get; set; } = String.Empty; // 默认当前时间
    public decimal Price { get; set; } // 价格，保留 1 位小数
}