namespace Core.Configs;

public record SpotifyConfig
{
    public string DeviceWhitelist { get; init; } = null!;
    public string BaseUrl { get; init; } = null!;
    public string SearchPath { get; init; } = null!;
    public string DevicesPath { get; init; } = null!;
    public string QueuePath { get; init; } = null!;
}