namespace Presentation.Models;

public record ArtistDto
{
    public required string ExternalUrl { get; init; }

    public required string Href { get; init; }

    public required string Id { get; init; }

    public required string Name { get; init; }

    public required string Uri { get; init; }
}