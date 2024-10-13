namespace Presentation.Models;

public record RecommendationsRequestDto
{
    public required string TrackId { get; init; }
}