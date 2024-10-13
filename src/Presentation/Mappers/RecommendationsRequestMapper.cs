using Core.Models;
using Core.ValueObjects;
using Presentation.Models;

namespace Presentation.Mappers;

public static class RecommendationsRequestMapper
{
    public static RecommendationsRequest Map(RecommendationsRequestDto recommendationsRequestDto)
    {
        return new RecommendationsRequest
        {
            ItemId = new ItemId(recommendationsRequestDto.TrackId),
            Limit = recommendationsRequestDto.Limit.HasValue ? new Limit(recommendationsRequestDto.Limit.Value) : null
        };
    }
}