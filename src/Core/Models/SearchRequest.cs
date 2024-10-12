using Core.Enums;
using Core.ValueObjects;

namespace Core.Models;

public record SearchRequest
{
    public required SearchQuery SearchQuery { get; init; }
    public required List<SearchType> Types { get; init; }
    public required Limit? Limit { get; init; }
    public required Offset? Offset { get; init; }
}