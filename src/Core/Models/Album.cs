using Core.ValueObjects;

namespace Core.Models;

public record Album
{
    public required Uri Href { get; init; }

    public required AlbumId Id { get; init; }

    public required List<Image> Images { get; init; } = [];

    public required AlbumName Name { get; init; }

    public required AlbumUri Uri { get; init; }

    public required Uri ExternalUrl { get; init; }
}