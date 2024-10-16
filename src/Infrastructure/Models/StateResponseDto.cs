﻿using System.Text.Json.Serialization;

namespace Infrastructure.Models;

public record StateResponseDto
{
    [JsonPropertyName("progress_ms")]
    public required int ProgressMs { get; init; }

    [JsonPropertyName("is_playing")]
    public required bool IsPlaying { get; init; }

    [JsonPropertyName("shuffle_state")]
    public required bool ShuffleState { get; init; }

    [JsonPropertyName("repeat_state")]
    public required string RepeatState { get; init; }

    [JsonPropertyName("device")]
    public required DeviceDto Device { get; init; }

    [JsonPropertyName("item")]
    public required ItemDto Item { get; init; }
}