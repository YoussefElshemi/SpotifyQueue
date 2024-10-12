using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public record ExternalUrlDto
{
    [JsonPropertyName("spotify")]
    public required string Spotify { get; init; }
}