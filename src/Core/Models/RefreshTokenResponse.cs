using Core.ValueObjects;

namespace Core.Models;

public record RefreshTokenResponse
{
    public required AccessToken AccessToken { get; init; }
    public required ExpiresIn ExpiresIn { get; init; }
}