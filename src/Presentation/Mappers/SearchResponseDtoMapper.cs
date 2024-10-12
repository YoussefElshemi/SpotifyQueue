using Core.Models;
using Presentation.Models;

namespace Presentation.Mappers;

public static class SearchResponseDtoMapper
{
    public static SearchResponseDto Map(SearchResponse searchResponse)
    {
        return new SearchResponseDto
        {
            Limit = searchResponse.Limit,
            Offset = searchResponse.Offset,
            Total = searchResponse.Total,
            Items = searchResponse.Items.Select(ItemDtoMapper.Map).ToList()
        };
    }
}