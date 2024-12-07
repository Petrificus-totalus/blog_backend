using probiotics.Dtos.Picture;
using probiotics.Models;

namespace probiotics.Mappers;

public static class PictureMapper
{
    public static PictureDto ToPictureDto(this Picture picture)
    {
        return new PictureDto
        {
            Id = picture.Id,
            Link = picture.Link,
        };
    }
}