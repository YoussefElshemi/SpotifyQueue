using Core.ValueObjects;

namespace Core.Models;

public record StateResponse
{
    public required ProgressMs ProgressMs { get; init; }

    public required IsPlaying IsPlaying { get; init; }

    public required Item Item { get; init; }
}