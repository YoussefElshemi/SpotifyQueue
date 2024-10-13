using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public record RecommendationResponseDto
{
    [JsonPropertyName("tracks")]
    public required List<ItemDto> Tracks { get; init; } = [];
}