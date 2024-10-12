namespace Presentation.Models;

public record QueueResponseDto
{
    public ItemDto? CurrentlyPlaying { get; init; }
    public List<ItemDto> Queue { get; init; } = [];
}