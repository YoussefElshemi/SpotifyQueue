using Core.ValueObjects;

namespace Presentation.Models;

public record StateResponseDto
{
    public required int ProgressMs { get; init; }
    public required bool IsPlaying { get; init; }
    public required bool ShuffleState { get; init; }
    public required string RepeatState { get; set; }
    public required ItemDto Item { get; init; }
}