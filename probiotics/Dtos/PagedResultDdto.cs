namespace probiotics.Dtos;


public class PagedResultDto<T>
{
    public int TotalPages { get; set; } // 总页数
    public List<T> Data { get; set; } = new(); // 数据列表
}
