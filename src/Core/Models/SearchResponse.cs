using Core.ValueObjects;

namespace Core.Models;

public record SearchResponse
{
    public required List<Item> Items { get; init; } = [];
    public Offset Offset { get; init; }
    public Limit Limit { get; init; }
    public Total Total { get; init; }
}