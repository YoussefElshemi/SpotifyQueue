using Core.ValueObjects;

namespace Core.Models;

public record Item
{
    public required ItemId Id { get; init; }

    public required Album Album { get; init; }

    public required List<Artist> Artists { get; init; } = [];

    public required Duration DurationMs { get; init; }

    public required Uri Href { get; init; }

    public required ItemName Name { get; init; }

    public required Uri ExternalUrl { get; init; }
    public required Uri? PreviewUrl { get; init; }

    public required ItemUri Uri { get; init; }

    public required List<Image> Images { get; init; } = [];
}