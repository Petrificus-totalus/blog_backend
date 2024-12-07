using probiotics.Dtos.Tag;
using probiotics.Models;

namespace probiotics.Mappers;

public static class TagMapper
{
    public static TagDto FromSpendTagToTagDto(this SpendTag spendTag)
    {
        return new TagDto
        {
            Id = spendTag.TagId,
            TagName = spendTag.Tag.TagName
        };
    }
    public static TagDto ToTagDto(this Tag tag)
    {
        return new TagDto
        {
            Id = tag.Id,
            TagName = tag.TagName
        };
    }
}