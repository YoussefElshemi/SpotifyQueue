namespace Presentation.Models;

public record SearchRequestDto
{
    public required string SearchQuery { get; init; }
    public int? Offset { get; init; }
    public int? Limit { get; init; }
}