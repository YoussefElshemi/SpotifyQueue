using Core.Models;
using Core.ValueObjects;
using Infrastructure.Models;

namespace Infrastructure.Mappers;

public static class RecommendationResponseMapper
{
    public static RecommendationsResponse Map(RecommendationResponseDto recommendationsResponseDto)
    {
        return new RecommendationsResponse
        {
            Items = recommendationsResponseDto.Tracks.Select(ItemMapper.Map).ToList()
        };
    }
}