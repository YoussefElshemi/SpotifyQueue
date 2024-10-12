using Core.ValueObjects;

namespace Core.Models;

public record Artist
{
    public required Uri ExternalUrl { get; init; }

    public required Uri Href { get; init; }

    public required ArtistId Id { get; init; }

    public required ArtistName Name { get; init; }

    public required ArtistUri Uri { get; init; }
}