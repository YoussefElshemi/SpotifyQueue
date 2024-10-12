using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public record QueueResponseDto
{
    [JsonPropertyName("currently_playing")]
    public required ItemDto? CurrentlyPlaying { get; init; }

    [JsonPropertyName("queue")]
    public required List<ItemDto> Queue { get; init; } = [];
}