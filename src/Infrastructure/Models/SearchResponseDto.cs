using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public record SearchResponseDto
{
    [JsonPropertyName("tracks")]
    public required TracksDto Tracks { get; init; }
}