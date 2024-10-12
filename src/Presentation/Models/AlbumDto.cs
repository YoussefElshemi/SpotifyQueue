namespace Presentation.Models;

public record AlbumDto
{
    public required string Href { get; init; }

    public required string Id { get; init; }

    public required List<ImageDto> Images { get; init; } = [];

    public required string Name { get; init; }

    public required string Uri { get; init; }

    public required string ExternalUrl { get; init; }
}