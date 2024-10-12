using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public record TracksDto
{
    [JsonPropertyName("limit")]
    public required int Limit { get; init; }

    [JsonPropertyName("offset")]
    public required int Offset { get; init; }

    [JsonPropertyName("total")]
    public required int Total { get; init; }

    [JsonPropertyName("items")]
    public required ItemDto[] Items { get; init; } = [];
}