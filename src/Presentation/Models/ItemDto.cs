namespace Presentation.Models;

public record ItemDto
{
    public required string Id { get; init; }

    public required AlbumDto Album { get; init; }

    public required List<ArtistDto> Artists { get; init; } = [];

    public required int DurationMs { get; init; }

    public required string Href { get; init; }

    public required string Name { get; init; }

    public required string ExternalUrl { get; init; }
    public required string? PreviewUrl { get; init; }

    public required string Uri { get; init; }

    public required List<ImageDto> Images { get; init; } = [];
}