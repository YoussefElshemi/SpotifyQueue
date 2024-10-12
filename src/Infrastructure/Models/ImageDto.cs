using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public record ImageDto
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("height")]
    public required int Height { get; init; }

    [JsonPropertyName("width")]
    public required int Width { get; init; }
}