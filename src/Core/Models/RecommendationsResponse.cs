namespace Core.Models;

public record RecommendationsResponse
{
    public required List<Item> Items { get; init; }
}