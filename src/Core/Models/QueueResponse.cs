namespace Core.Models;

public record QueueResponse
{
    public required Item? CurrentlyPlaying { get; init; }
    public required List<Item> Queue { get; init; } = [];
}