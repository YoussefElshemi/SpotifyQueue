using Core.Enums;
using Core.ValueObjects;

namespace Core.Models;

public record RecommendationsRequest
{
    public required ItemId ItemId { get; init; }
    public required Limit? Limit { get; init; }
}