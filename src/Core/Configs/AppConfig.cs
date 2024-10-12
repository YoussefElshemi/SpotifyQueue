namespace Core.Configs;

public record AppConfig
{
    public SpotifyAuthConfig SpotifyAuthConfig { get; init; } = null!;
    public SpotifyConfig SpotifyConfig { get; init; } = null!;
}