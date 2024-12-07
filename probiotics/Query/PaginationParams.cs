using System.ComponentModel.DataAnnotations;

namespace probiotics.Query;

public class PaginationParams
{
    [Range(1, int.MaxValue, ErrorMessage = "Page number must be greater than 0")]
    public int PageNumber { get; set; } = 1; // 默认第一页

    [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100")]
    public int PageSize { get; set; } = 3; // 默认每页 10 条记录
}