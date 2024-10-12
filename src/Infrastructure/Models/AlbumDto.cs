using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public record AlbumDto
{
    [JsonPropertyName("external_urls")]
    public required ExternalUrlDto ExternalUrl { get; init; }

    [JsonPropertyName("href")]
    public required string Href { get; init; }

    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("images")]
    public ImageDto[] Images { get; init; } = [];

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("uri")]
    public required string Uri { get; init; }
}