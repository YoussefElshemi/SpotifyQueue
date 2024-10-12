using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public record ItemDto
{
    [JsonPropertyName("album")]
    public required AlbumDto Album { get; init; }

    [JsonPropertyName("artists")]
    public required ArtistDto[] Artists { get; init; } = [];

    [JsonPropertyName("duration_ms")]
    public required int DurationMs { get; init; }

    [JsonPropertyName("external_urls")]
    public required ExternalUrlDto ExternalUrl { get; init; }

    [JsonPropertyName("href")]
    public required string Href { get; init; }

    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("preview_url")]
    public required string? PreviewUrl { get; init; }

    [JsonPropertyName("uri")]
    public required string Uri { get; init; }

    [JsonPropertyName("images")]
    public ImageDto[] Images { get; init; } = [];
}