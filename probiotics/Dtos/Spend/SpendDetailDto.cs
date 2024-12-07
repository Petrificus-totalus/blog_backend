using probiotics.Dtos.Picture;

namespace probiotics.Dtos.Spend;

public class SpendDetailDto
{
    public int Id { get; set; }
    public string? Description { get; set; } // 长文本描述

    public List<PictureDto> Pictures { get; set; } = new();
}