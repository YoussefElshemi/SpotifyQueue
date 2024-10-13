namespace Presentation.Models;

public record RecommendationsResponseDto
{
    public required ItemDto[] Items { get; init; }
}