using probiotics.Dtos.Swallow;
using probiotics.Models;

namespace probiotics.Mappers;

public static class SwallowLinkMapper
{
    public static SwallowLinkDto ToSwallowLinkDto(this SwallowLink link)
    {
        return new SwallowLinkDto
        {
            Id = link.Id,
            Link = link.Link,
            SwallowId = link.SwallowId,
        };
    }
    public static SwallowLink ToSwallowLinkFromCreate(this CreateLinkDto link,int swallowId)
    {
        return new SwallowLink
        {
            Link = link.Link,
            SwallowId = swallowId
        };
    }
}