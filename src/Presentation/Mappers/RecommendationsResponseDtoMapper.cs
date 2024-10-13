using Core.Models;
using Presentation.Models;

namespace Presentation.Mappers;

public static class RecommendationsResponseDtoMapper
{
    public static RecommendationsResponseDto Map(RecommendationsResponse searchResponse)
    {
        return new RecommendationsResponseDto
        {
            Items = searchResponse.Items.Select(ItemDtoMapper.Map).ToArray()
        };
    }
}