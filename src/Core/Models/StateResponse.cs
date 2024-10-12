using Core.ValueObjects;

namespace Core.Models;

public record StateResponse
{
    public required ProgressMs ProgressMs { get; init; }
    public required IsPlaying IsPlaying { get; init; }
    public required ShuffleState ShuffleState { get; init; }
    public required RepeatState RepeatState { get; init; }
    public required Device Device { get; init; }
    public required Item Item { get; init; }
}