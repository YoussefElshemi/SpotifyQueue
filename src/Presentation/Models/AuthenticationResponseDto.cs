namespace Presentation.Models;

public record AuthenticationResponseDto
{
    public required string AccessToken { get; init; }
}