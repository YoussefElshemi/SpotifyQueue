using Core.ValueObjects;

namespace Core.Models;

public record AuthenticationResponse
{
    public required AccessToken AccessToken { get; init; }
    public required RefreshToken RefreshToken { get; init; }
    public required ExpiresIn ExpiresIn { get; init; }
}