namespace Core.Configs;

public record SpotifyAuthConfig
{
    public string ClientId { get; init; } = null!;
    public string ClientSecret { get; init; } = null!;
    public string Scope { get; init; } = null!;
    public string RedirectUri { get; init; } = null!;
    public string BaseUrl { get; init; } = null!;
    public string AuthenticationPath { get; init; } = null!;
    public string AuthorizePath { get; init; } = null!;
}