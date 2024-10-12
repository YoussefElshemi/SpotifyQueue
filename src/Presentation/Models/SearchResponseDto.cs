namespace Presentation.Models;

public record SearchResponseDto
{
    public required int Limit { get; init; }
    public required int Offset { get; init; }
    public required int Total { get; init; }
    public required List<ItemDto> Items { get; init; } = [];
}