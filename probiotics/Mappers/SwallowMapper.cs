using probiotics.Dtos.Swallow;
using probiotics.Models;

namespace probiotics.Mappers;

public static class SwallowMapper
{
    public static SwallowDto ToSwallowDto(this Swallow swallowModel)
    {
        return new SwallowDto
        {
            Id = swallowModel.Id,
            Rating = swallowModel.Rating,
            Restaurant = swallowModel.Restaurant,
            Summary = swallowModel.Summary,
            CoverImage = swallowModel.CoverImage,
            CreateTime = swallowModel.CreateTime,
        };
    }
    public static SwallowDetailDto ToSwallowDetailDto(this Swallow swallowModel)
    {
        return new SwallowDetailDto
        {
            Id = swallowModel.Id,
            Rating = swallowModel.Rating,
            Restaurant = swallowModel.Restaurant,
            Review = swallowModel.Review,
            Links = new List<string> { swallowModel.CoverImage }
                .Concat(swallowModel.Links.Select(c => c.Link))
                .ToList()
            };
    }
    public static Swallow ToSwallowFromCreateSwallowDto(this CreateSwallowDto swallowModel)
    {
        return new Swallow
        {
            Rating = swallowModel.Rating,
            Restaurant = swallowModel.Restaurant,
            Summary = swallowModel.Summary,
            Review = swallowModel.Review,
            CoverImage = swallowModel.CoverImage,
            CreateTime = swallowModel.CreateTime,
        };
    }
}