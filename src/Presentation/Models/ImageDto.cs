namespace Presentation.Models;

public record ImageDto
{
    public required int Width { get; init; }
    public required int Height { get; init; }
    public required string Url { get; init; }
}