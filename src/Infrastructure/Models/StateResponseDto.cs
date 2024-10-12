using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public record StateResponseDto
{
    [JsonPropertyName("progress_ms")]
    public required int ProgressMs { get; init; }

    [JsonPropertyName("is_playing")]
    public required bool IsPlaying { get; init; }

    [JsonPropertyName("item")]
    public required ItemDto Item { get; init; }
}