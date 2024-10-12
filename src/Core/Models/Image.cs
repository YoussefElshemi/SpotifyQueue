using Core.ValueObjects;

namespace Core.Models;

public record Image
{
    public required ImageWidth Width { get; init; }
    public required ImageHeight Height { get; init; }
    public required Uri Url { get; init; }
}